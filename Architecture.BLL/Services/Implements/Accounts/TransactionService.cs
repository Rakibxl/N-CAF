using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Interfaces.Accounts;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities;
using Architecture.Core.Entities.Accounts;
using Architecture.Core.Entities.Notification;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                    //    MessageContent = $"Your account has been synchronized successfully at {(DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss tt"))}. \n" +
                    //   $"<b> A/C Number:  {result.AccountNumber}</b>\n <b> A/C Name:  {result.AccountName}</b>",
                    //    MessageFor = result.CreatedBy
                    //});
                }
                else
                {
                    transactionInfo.CreatedBy = _currentUserService.UserId;
                    transactionInfo.Created = DateTime.Now;
                    transactionInfo.RecordStatusId = (int)EnumRecordStatus.Active;
                    result = await AddAsync(transactionInfo);

                    //await this.notificationService.AddOrUpdate(new NotificationInfo
                    //{
                    //    MessageContent = $"Your account has been synchronized successfully at {(DateTime.Now.ToString("dd/mm/yyyy hh:mm:ss tt"))}. \n" +
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
                MessageContent = $"{offerInfo.Code} has submitted successfully and deducted {transaction.Amount} points from your account <b>{requestAccountInfo.AccountNumber}</b>\nCreated by {_currentUserService.UserName} on {DateTime.UtcNow:f}"
            };
            await _notificationService.AddOrUpdate(notificationInfoTransaction);
        }

        public async Task<string> Delete(int transactionId)
        {
            Transaction result = await GetFirstOrDefaultAsync(x => x, x => x.TransactionId == transactionId && x.RecordStatusId != (int)EnumRecordStatus.Deleted);
            if (result == null)
            {
                return "Accounts infomration is not available. Please contact with admin.";
            }
            result.Modified = DateTime.Now;
            result.ModifiedBy = _currentUserService.UserId;
            result.RecordStatusId = (int)EnumRecordStatus.Deleted;
            await UpdateAsync(result);
            return "Information deleted successfully.";
        }
    }
}
