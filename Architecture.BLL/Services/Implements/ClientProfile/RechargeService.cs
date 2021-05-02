using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Interfaces.Accounts;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities.Accounts;
using Architecture.Core.Entities.Notification;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class RechargeService : Repository<TransactionRequest>, IRechargeService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;
        private readonly INotificationService _notificationService;
        private readonly IAccountInfoService _accountInfoService;

        public RechargeService(ApplicationDbContext context, ICurrentUserService currentUserService, INotificationService notificationService, IAccountInfoService accountInfoService) : base(context)
        {
            _context = context;
            _currentUserService = currentUserService;
            _notificationService = notificationService;
            _accountInfoService = accountInfoService;
        }

        public async Task<TransactionRequest> AddOrUpdateAsync(TransactionRequest transactionRequest)
        {
            TransactionRequest result;

            if (transactionRequest.TransactionRequestId > 0)
            {
                transactionRequest.ModifiedBy = _currentUserService.UserId;

                result = await UpdateAsync(transactionRequest);
            }
            else
            {
                transactionRequest.RecordStatusId = (int)EnumRecordStatus.WaitingforApproval;
                transactionRequest.CreatedBy = transactionRequest.RequestBy = _currentUserService.UserId;

                result = await AddAsync(transactionRequest);
            }

            var adminAccountInfo = await _context.AccountInfos.FirstOrDefaultAsync(x => x.AppUserTypeId == (int)EnumAppUserType.Admin);
            NotificationInfo notificationInfo = new NotificationInfo
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Active,
                MessageFor = adminAccountInfo.NotifyUserId,
                MessageContent = $"{result.Amount} point transaction request has been placed for your approval by {_currentUserService.UserName} on {DateTime.UtcNow:f}"
            };

            await _notificationService.AddOrUpdate(notificationInfo);
            return result;
        }

        public async Task<IEnumerable<TransactionRequest>> GetRechargeRequestsAsync()
        {
            if (_currentUserService.UserTypeId == (int)EnumAppUserType.Client)
                return await GetAsync(x => x, x => x.CreatedBy == _currentUserService.UserId, x => x.OrderByDescending(y => y.Created), x => x.Include(z => z.RecordStatus));

            return await GetAsync(x => x, x => x.RecordStatusId == (int)EnumRecordStatus.WaitingforApproval, x => x.OrderByDescending(y => y.Created), x => x.Include(z => z.RecordStatus));
        }

        public async Task<IEnumerable<TransactionDetail>> GetTransactionHistoriesAsync()
        {
            AccountInfo requestAccountInfo = await _accountInfoService.GetCurrentUserAccountInfo();
            if (requestAccountInfo==null) {
                throw new Exception("You account information is not sync. Please sync your account information.");
            }
            var transactionHistory= await _context.TransactionDetails
                .Include(z => z.RecordStatus)
                //.Include(x=>x.Transaction)
                     .Where(x => x.AccountInfoId== requestAccountInfo.AccountInfoId)
                     .OrderByDescending(x => x.Created)
                     .ToListAsync();

            //Auto mapper 
            return transactionHistory;
        }

        public async Task<bool> ApprovePendingRechargeAsync(int transactionRequestId)
        {
            TransactionRequest result = await GetByIdAsync(transactionRequestId);

            if (result != null)
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();
                var transactionDataInsertResult = await SaveTransactionAsync(result);
                //await SaveTransactionDetailsAsync(result, transactionDataInsertResult);


                await UpdateTransactionRequestAsync(result, transactionDataInsertResult);

                await NotifyUserAsync(result);
                await transaction.CommitAsync();
            }

            return true;
        }

        private async Task NotifyUserAsync(TransactionRequest request)
        {
            try
            {
                NotificationInfo notificationInfo = new NotificationInfo
                {
                    CreatedBy = _currentUserService.UserId,
                    Created = DateTime.UtcNow,
                    RecordStatusId = (int)EnumRecordStatus.Active,
                    MessageFor = request.CreatedBy,
                    MessageContent = $"Your transaction request has been approved by {_currentUserService.UserName} on {DateTime.UtcNow:f}"
                };

                await _notificationService.AddOrUpdate(notificationInfo);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }

        private async Task<EntityEntry<Transaction>> SaveTransactionAsync(TransactionRequest result)
        {
            var transactionObj = new Transaction
            {
                CreatedBy = _currentUserService.UserId,
                RecordStatusId = (int)EnumRecordStatus.Approved,
                TransactionPurpose = result.Purpose,
                ApprovedDate = result.Modified = DateTime.UtcNow,
                ApprovedBy = _currentUserService.UserId,
                IsAutoAccounting = true,
                Amount = result.Amount,
                TransactionRequestId = result.TransactionRequestId,
                TransactionDetail = await GetTransactionDetailsAsync(result)
            };

            var transactionDataInsertResult = await _context.Transactions.AddAsync(transactionObj);
            return transactionDataInsertResult;
        }

        private async Task<List<TransactionDetail>> GetTransactionDetailsAsync(TransactionRequest result)
        {
            var adminAccountInfo = await _context.AccountInfos.FirstOrDefaultAsync(x => x.AppUserTypeId == (int)EnumAppUserType.Admin);

            var transactionDetailsCreditObj = new TransactionDetail
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Approved,
               // TransactionId = transactionDataInsertResult.Entity.TransactionId,
                Credit = result.Amount,
                AccountInfoId = adminAccountInfo.AccountInfoId
            };

           // await _context.TransactionDetails.AddAsync(transactionDetailsCreditObj);


            AccountInfo requestAccountInfo = await _accountInfoService.GetAccountInfoByUserId(result.RequestBy);
            var transactionDetailsDebitObj = new TransactionDetail
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Approved,
                //TransactionId = transactionDataInsertResult.Entity.TransactionId,
                Debit = result.Amount,
                AccountInfoId = requestAccountInfo.AccountInfoId
            };

            List<TransactionDetail> transactionDetails = new List<TransactionDetail>() { transactionDetailsCreditObj, transactionDetailsDebitObj };

            return transactionDetails;
            //await _context.TransactionDetails.AddAsync(transactionDetailsDebitObj);
        }


        private async Task UpdateTransactionRequestAsync(TransactionRequest transactionRequest, EntityEntry<Transaction> transactionDataInsertResult)
        {
            transactionRequest.RecordStatusId = (int)EnumRecordStatus.Approved;
            transactionRequest.ApprovedDate = transactionRequest.Modified = DateTime.UtcNow;
            transactionRequest.ApprovedBy = _currentUserService.UserId;
            transactionRequest.ModifiedBy = _currentUserService.UserId;
            //transactionRequest.TransactionId = transactionDataInsertResult.Entity.TransactionId;
            await UpdateAsync(transactionRequest);
        }


        public async Task<bool> RejectPendingRechargeAsync(int transactionRequestId)
        {
            TransactionRequest result = await GetByIdAsync(transactionRequestId);

            if (result != null)
            {
                result.RecordStatusId = (int)EnumRecordStatus.Deleted;
                result.ModifiedBy = _currentUserService.UserId;
                result.Modified = DateTime.UtcNow;

                await UpdateAsync(result);
            }

            return true;
        }
    }
}
