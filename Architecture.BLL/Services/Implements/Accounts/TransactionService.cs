using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Interfaces.Accounts;
using Architecture.BLL.Services.Models;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities;
using Architecture.Core.Entities.Accounts;
using Architecture.Core.Entities.Notification;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements.Accounts
{
    public class TransactionService : Repository<Transaction>, ITransactionService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly INotificationService _notificationService;
        private readonly IAccountInfoService _accountInfoService;
        private readonly IJobInformationService _jobInformationService;
        private readonly ApplicationDbContext _context;
        public TransactionService(ApplicationDbContext dbContext, ICurrentUserService currentUserService, IAccountInfoService accountInfoService,
            IJobInformationService jobInformationService, INotificationService notificationService) : base(dbContext)
        {
            _currentUserService = currentUserService;
            _context = dbContext;
            _accountInfoService = accountInfoService;
            _jobInformationService = jobInformationService;
            _notificationService = notificationService;
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            IEnumerable<Transaction> result;
            result = await GetAsync(x => x, x => x.RecordStatusId == (int)EnumRecordStatus.Active);
            return result;
        }
        public async Task<IEnumerable<TransactionDetailVM>> GetPendingApproval()
        {
            var pendingApproval =from t in _dbContext.Transactions.Where(x=>x.RecordStatusId==(int) EnumRecordStatus.WaitingforApproval && x.OfferInfoId!=null)
                                 join of in _dbContext.OfferInfos on t.OfferInfoId equals of.OfferInfoId
                                 join op in _dbContext.Users on t.CreatedBy equals op.Id 
                                 select new TransactionDetailVM()
                                 {
                                     TransactionId = t.TransactionId,
                                     TransactionPurpose = t.TransactionPurpose,
                                     Amount = t.Amount,
                                     CratedByName = op.FullName,
                                     Created = t.Created,
                                     Modified = t.Modified,
                                     OfferInfo=of
                                 };
            
            return pendingApproval.OrderByDescending(x => x.TransactionId);
        }


        public async Task<string> ApprovalRejectOperatorAmount(int transactionId, string status)
        {
            var checkVal = await IsExistsAsync(x => x.TransactionId == transactionId);
            if (checkVal)
            {
                var result =await _dbContext.Transactions.Include(x=>x.TransactionDetail).FirstOrDefaultAsync(x=>x.TransactionId== transactionId);
                result.RecordStatusId = (int)EnumRecordStatus.Approved;
                result.ApprovedBy = _currentUserService.UserId;
                result.ApprovedDate = DateTime.UtcNow;
                foreach (var obj in result.TransactionDetail) {
                    obj.RecordStatusId = (int)EnumRecordStatus.Approved;
                }

                await AddOrUpdate(result);
                return "Successfully your command executed.";
            }
            else
            {
                throw new Exception("Information is not availalbe. Please contact with admin.");
            }
        }

        public async Task<Transaction> GetById(int transactionId)
        {
            var checkVal = await IsExistsAsync(x => x.TransactionId == transactionId && x.RecordStatusId == (int)EnumRecordStatus.Approved);
            if (checkVal)
            {
                Transaction result = await GetByIdAsync(transactionId);
                return result;
            }
            else
            {
                throw new Exception("Information is not availalbe. Please contact with admin.");
            }
        }


        public async Task<Transaction> AddOrUpdate(Transaction transactionInfo)
        {
            try
            {
                Transaction result;
                if (transactionInfo.TransactionId > 0)
                {
                    transactionInfo.ModifiedBy = _currentUserService.UserId;
                    transactionInfo.Modified = DateTime.UtcNow;
                    result = await UpdateAsync(transactionInfo);

                    //await _notificationService.AddOrUpdate(new NotificationInfo
                    //{
                    //    MessageContent = $"Your account has been synchronized successfully at {(DateTime.UtcNow.ToString("dd/mm/yyyy hh:mm:ss tt"))}. \n" +
                    //   $"<b> A/C Number:  {result.AccountNumber}</b>\n <b> A/C Name:  {result.AccountName}</b>",
                    //    MessageFor = result.CreatedBy
                    //});
                }
                else
                {
                    transactionInfo.CreatedBy = _currentUserService.UserId;
                    transactionInfo.Created = DateTime.UtcNow;
                    transactionInfo.RecordStatusId = (int)EnumRecordStatus.Active;
                    result = await AddAsync(transactionInfo);

                    //await this.notificationService.AddOrUpdate(new NotificationInfo
                    //{
                    //    MessageContent = $"Your account has been synchronized successfully at {(DateTime.UtcNow.ToString("dd/mm/yyyy hh:mm:ss tt"))}. \n" +
                    //    $"<b> A/C Number:  {result.AccountNumber}</b>\n <b> A/C Name:  {result.AccountName}</b>",
                    //    MessageFor = result.CreatedBy
                    //});
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Offer Related
        public async Task<Transaction> CreateTransactionForOfferSubmit(OfferInfo offerInfo)
        {
            decimal amount = 0;
            var JobInfo = await _jobInformationService.GetById(offerInfo.JobId);
            if (_currentUserService.UserTypeId == (int)EnumApplicationUserType.BranchUser)
            {
                amount = JobInfo.BranchRequiredAmount;
            }
            else {
                amount = JobInfo.ClientRequiredAmount;
            }
           
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    #region transaction details object
                    var adminAccountInfo = await _context.AccountInfos.FirstOrDefaultAsync(x => x.AppUserTypeId == (int)EnumAppUserType.Admin);

                    List<TransactionDetail> transactionDetailsCreditObj = new List<TransactionDetail>();
                    transactionDetailsCreditObj.Add(new TransactionDetail
                    {
                        CreatedBy = _currentUserService.UserId,
                        Created = DateTime.UtcNow,
                        RecordStatusId = (int)EnumRecordStatus.Approved,
                        //TransactionId = transactionDataInsertResult.Entity.TransactionId,
                        Debit = amount,
                        Credit = 0,
                        AccountInfoId = adminAccountInfo.AccountInfoId
                    });


                    AccountInfo requestAccountInfo = await _accountInfoService.GetCurrentUserAccountInfo();
                    transactionDetailsCreditObj.Add(new TransactionDetail
                    {
                        CreatedBy = _currentUserService.UserId,
                        Created = DateTime.UtcNow,
                        RecordStatusId = (int)EnumRecordStatus.Approved,
                        //TransactionId = transactionDataInsertResult.Entity.TransactionId,
                        Credit = amount,
                        Debit = 0,
                        AccountInfoId = requestAccountInfo.AccountInfoId
                    });
                    #endregion transaction details object

                    //save transaction 
                    var transactionInfo = new Transaction
                    {
                        Amount = amount,
                        TransactionPurpose = $"{offerInfo.Code} has submitted and deducted {JobInfo.ClientRequiredAmount} points.",
                        OfferInfoId = offerInfo.OfferInfoId,
                        RecordStatusId = (int)EnumRecordStatus.Approved,
                        ApprovedDate = DateTime.UtcNow,
                        ApprovedBy = _currentUserService.UserId,
                        IsAutoAccounting = true,
                        CreatedBy = _currentUserService.UserId,
                        Created = DateTime.UtcNow,
                        TransactionDetail= transactionDetailsCreditObj
                    };
                    var transactionDataInsertResult = await _context.Transactions.AddAsync(transactionInfo);
                    await NotifyUserAfterSubmitOfferAsync(offerInfo, requestAccountInfo, adminAccountInfo, transactionInfo);
                    await transaction.CommitAsync();
                }               

           
            return new Transaction();
        }
         public async Task<Transaction> CreateTransactionForAcceptOffer(OfferInfo offerInfo)
        {
            decimal amount = 0;
            var JobInfo = await _jobInformationService.GetById(offerInfo.JobId);
            if (_currentUserService.UserTypeId == (int)EnumApplicationUserType.BranchUser)
            {
                amount = JobInfo.OperatorRequiredAmount;
            }
            else {
                amount = JobInfo.OperatorRequiredAmount;
            }
           
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    #region transaction details object
                    var adminAccountInfo = await _context.AccountInfos.FirstOrDefaultAsync(x => x.AppUserTypeId == (int)EnumAppUserType.Admin);

                    List<TransactionDetail> transactionDetailsCreditObj = new List<TransactionDetail>();
                    transactionDetailsCreditObj.Add(new TransactionDetail
                    {
                        CreatedBy = _currentUserService.UserId,
                        Created = DateTime.UtcNow,
                        RecordStatusId = (int)EnumRecordStatus.Pending,
                        //TransactionId = transactionDataInsertResult.Entity.TransactionId,
                        Debit = 0,
                        Credit = amount,
                        AccountInfoId = adminAccountInfo.AccountInfoId
                    });


                    AccountInfo requestAccountInfo = await _accountInfoService.GetCurrentUserAccountInfo();
                    transactionDetailsCreditObj.Add(new TransactionDetail
                    {
                        CreatedBy = _currentUserService.UserId,
                        Created = DateTime.UtcNow,
                        RecordStatusId = (int)EnumRecordStatus.Pending,
                        //TransactionId = transactionDataInsertResult.Entity.TransactionId,
                        Credit = 0,
                        Debit = amount,
                        AccountInfoId = requestAccountInfo.AccountInfoId
                    });
                    #endregion transaction details object

                    //save transaction 
                    var transactionInfo = new Transaction
                    {
                        Amount = amount,
                        TransactionPurpose = $"{offerInfo.Code} has accepted and added {amount} points.",
                        OfferInfoId = offerInfo.OfferInfoId,
                        RecordStatusId = (int)EnumRecordStatus.Pending,
                        //ApprovedDate = DateTime.UtcNow,
                        //ApprovedBy = _currentUserService.UserId,
                        IsAutoAccounting = false,
                        CreatedBy = _currentUserService.UserId,
                        Created = DateTime.UtcNow,
                        TransactionDetail= transactionDetailsCreditObj
                    };
                    var transactionDataInsertResult = await _context.Transactions.AddAsync(transactionInfo);
                    await NotifyUserAfterAcceptOfferAsync(offerInfo, requestAccountInfo, adminAccountInfo, transactionInfo);
                    await transaction.CommitAsync();
                }               

           
            return new Transaction();
        }

        public async Task<string> DeletedTransactionForRevertOffer(OfferInfo offerInfo)
        {
            var transactions = await GetAsync(x=>x, x=>x.OfferInfoId== offerInfo.OfferInfoId && x.CreatedBy==_currentUserService.UserId);
            if (transactions==null) {
                return "Transaction has problem. Please contact with admin.";
            }

            var transaction = transactions[0];
            transaction.ModifiedBy = _currentUserService.UserId;
            transaction.Modified = DateTime.UtcNow;
            transaction.RecordStatusId = (int)EnumRecordStatus.Deleted;
            await AddOrUpdate(transaction);


            //requester notification
            NotificationInfo notificationInfoTransaction = new NotificationInfo
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Active,
                MessageFor = transaction.CreatedBy,
                MessageContent = $"{offerInfo.Code} has reverted successfully and deducted {transaction.Amount} points from your account </b>\nCreated by System Admin on {DateTime.UtcNow:f}"
            };
            await _notificationService.AddOrUpdate(notificationInfoTransaction);


            //client notificaiton
            NotificationInfo clientNotificationInfo = new NotificationInfo
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Active,
                MessageFor = offerInfo.CreatedBy,
                OfferInfoId = offerInfo.OfferInfoId,
                MessageContent = $"{offerInfo.Code} has reverted by operator {_currentUserService.UserName}. Now the offer is open for the all operator form {DateTime.UtcNow:f}"
            };
            await _notificationService.AddOrUpdate(clientNotificationInfo);

            return $"{offerInfo.Code} Reverted Successfully.";
        }
        public async Task<string> CreateTransactionForCompletedOffer(OfferInfo offerInfo)
        {
            var transactions = await GetAsync(x=>x, x=>x.OfferInfoId== offerInfo.OfferInfoId && x.CreatedBy==_currentUserService.UserId);
            if (transactions.Count==0) {
                return "Transaction has problem. Please contact with admin.";
            }

            var transaction = transactions[0];
            transaction.ModifiedBy = _currentUserService.UserId;
            transaction.Modified = DateTime.UtcNow;
            transaction.RecordStatusId = (int)EnumRecordStatus.WaitingforApproval;
            await AddOrUpdate(transaction);


            //operator notification
            NotificationInfo notificationInfoTransaction = new NotificationInfo
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Active,
                MessageFor = transaction.CreatedBy,
                //OfferInfoId=offerInfo.OfferInfoId,
                MessageContent = $"{offerInfo.Code} has completed successfully and {transaction.Amount} points are waiting for the approval. \nCreated by System Admin on {DateTime.UtcNow:f}"
            };
            await _notificationService.AddOrUpdate(notificationInfoTransaction);


            //client notificaiton
            NotificationInfo clientNotificationInfo = new NotificationInfo
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Active,
                MessageFor = offerInfo.CreatedBy,
                OfferInfoId = offerInfo.OfferInfoId,
                MessageContent = $"{offerInfo.Code} has completed successfully by operator {_currentUserService.UserName}. Now the offer is available in your dashboard form {DateTime.UtcNow:f}"
            };
            await _notificationService.AddOrUpdate(clientNotificationInfo);

            //admin notificaiton
            var adminAccountInfo = await _context.AccountInfos.FirstOrDefaultAsync(x => x.AppUserTypeId == (int)EnumAppUserType.Admin);
            NotificationInfo adminNotificationInfo = new NotificationInfo
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Active,
                MessageFor = adminAccountInfo.NotifyUserId,
                OfferInfoId = offerInfo.OfferInfoId,
                MessageContent = $"{offerInfo.Code} has completed successfully by operator {_currentUserService.UserName}. Submit a request for payment approval on {DateTime.UtcNow:f}."
            };
            await _notificationService.AddOrUpdate(clientNotificationInfo);

            return $"{offerInfo.Code} Completed Successfully.";
        }
        #endregion offer related

        #region Private Method
        private async Task NotifyUserAfterSubmitOfferAsync(OfferInfo offerInfo, AccountInfo requestAccountInfo, AccountInfo adminAccountInfo, Transaction transaction)
        {
            //admin notification
            NotificationInfo notificationInfo = new NotificationInfo
            {
                CreatedBy = adminAccountInfo.NotifyUserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Active,
                MessageFor = adminAccountInfo.NotifyUserId,
                MessageContent = $"{offerInfo.Code} has submitted successfully and added {transaction.Amount} points in your account <b>{adminAccountInfo.AccountNumber}</b>\n Created by {_currentUserService.UserName} on {DateTime.UtcNow:f}"
            };
            await _notificationService.AddOrUpdate(notificationInfo);

            //requester notification
            NotificationInfo notificationInfoTransaction = new NotificationInfo
            {
                CreatedBy = adminAccountInfo.NotifyUserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Active,
                MessageFor = requestAccountInfo.NotifyUserId,
                OfferInfoId = offerInfo.OfferInfoId,
                MessageContent = $"{offerInfo.Code} has submitted successfully and deducted {transaction.Amount} points from your account <b>{requestAccountInfo.AccountNumber}</b>\nCreated by {_currentUserService.UserName} on {DateTime.UtcNow:f}"
            };
            await _notificationService.AddOrUpdate(notificationInfoTransaction);
        }
        private async Task NotifyUserAfterAcceptOfferAsync(OfferInfo offerInfo, AccountInfo requestAccountInfo, AccountInfo adminAccountInfo, Transaction transaction)
        {
            //operator notification
            NotificationInfo notificationInfo = new NotificationInfo
            {
                CreatedBy = adminAccountInfo.NotifyUserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Active,
                MessageFor = requestAccountInfo.NotifyUserId,
                MessageContent = $"{offerInfo.Code} has accepted successfully and added {transaction.Amount} points in your account <b>{requestAccountInfo.AccountNumber}</b>\n Created by System Account on {DateTime.UtcNow:f}"
            };
            await _notificationService.AddOrUpdate(notificationInfo);

            //client notificaiton
            NotificationInfo clientNotificationInfo = new NotificationInfo
            {
                CreatedBy = adminAccountInfo.NotifyUserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Active,
                MessageFor = offerInfo.CreatedBy,
                OfferInfoId=offerInfo.OfferInfoId,
                MessageContent = $"{offerInfo.Code} has accepted successfully and operator {_currentUserService.UserName} has started to proceed the file from {DateTime.UtcNow:f}"
            };
            await _notificationService.AddOrUpdate(clientNotificationInfo);
        }


        #endregion Private Method
        public async Task<string> Delete(int transactionId)
        {
            Transaction result = await GetFirstOrDefaultAsync(x => x, x => x.TransactionId == transactionId && x.RecordStatusId != (int)EnumRecordStatus.Deleted);
            if (result == null)
            {
                return "Accounts infomration is not available. Please contact with admin.";
            }
            result.Modified = DateTime.UtcNow;
            result.ModifiedBy = _currentUserService.UserId;
            result.RecordStatusId = (int)EnumRecordStatus.Deleted;
            await UpdateAsync(result);
            return "Information deleted successfully.";
        }
    }
}
