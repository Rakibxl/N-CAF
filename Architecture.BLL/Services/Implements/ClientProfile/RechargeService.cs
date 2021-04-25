using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces;
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

        public RechargeService(ApplicationDbContext context, ICurrentUserService currentUserService, INotificationService notificationService) : base(context)
        {
            _context = context;
            _currentUserService = currentUserService;
            _notificationService = notificationService;
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
            AccountInfo requestAccountInfo = null;

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == _currentUserService.UserId);
            if (user != null)
            {
                if (user.AppUserTypeId == (int)EnumAppUserType.BranchUser)
                    requestAccountInfo = await _context.AccountInfos.FirstOrDefaultAsync(x => x.MasterId == user.BranchInfoId.ToString());

                else
                    requestAccountInfo = await _context.AccountInfos.FirstOrDefaultAsync(x => x.MasterId == user.Id.ToString());
            }

            return await _context.TransactionDetails.Include(z => z.RecordStatus)
                     .Where(x => x.CreatedBy.ToString() == requestAccountInfo.MasterId)
                     .OrderByDescending(x => x.Created)
                     .ToListAsync();
        }

        public async Task<bool> ApprovePendingRechargeAsync(int transactionRequestId)
        {
            TransactionRequest result = await GetByIdAsync(transactionRequestId);

            if (result != null)
            {
                await using var transaction = await _context.Database.BeginTransactionAsync();

                var transactionDataInsertResult = await SaveTransactionAsync(result);

                await SaveTransactionDetailsAsync(result, transactionDataInsertResult);

                await UpdateTransactionRequestAsync(result, transactionDataInsertResult);

                await NotifyUserAsync(result);

                await transaction.CommitAsync();
            }

            return true;
        }

        private async Task NotifyUserAsync(TransactionRequest request)
        {
            NotificationInfo notificationInfo = new NotificationInfo
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Approved,
                MessageFor = request.CreatedBy,
                MessageContent = $"Your recharge request has been approved by {_currentUserService.UserName} on {DateTime.UtcNow:f}"
            };

            await _notificationService.AddOrUpdate(notificationInfo);
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
                Amount = result.Amount
            };

            var transactionDataInsertResult = await _context.Transactions.AddAsync(transactionObj);
            return transactionDataInsertResult;
        }

        private async Task SaveTransactionDetailsAsync(TransactionRequest result, EntityEntry<Transaction> transactionDataInsertResult)
        {
            var adminAccountInfo = await _context.AccountInfos.FirstOrDefaultAsync(x => x.AppUserTypeId == (int)EnumAppUserType.Admin);

            var transactionDetailsCreditObj = new TransactionDetail
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Approved,
                TransactionId = transactionDataInsertResult.Entity.TransactionId,
                Credit = result.Amount,
                AccountInfoId = adminAccountInfo.AccountInfoId
            };

            await _context.TransactionDetails.AddAsync(transactionDetailsCreditObj);


            AccountInfo requestAccountInfo = null;

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == result.RequestBy);
            if (user != null)
            {
                if (user.AppUserTypeId == (int)EnumAppUserType.BranchUser)
                    requestAccountInfo = await _context.AccountInfos.FirstOrDefaultAsync(x => x.MasterId == user.BranchInfoId.ToString());

                else
                    requestAccountInfo = await _context.AccountInfos.FirstOrDefaultAsync(x => x.MasterId == user.Id.ToString());
            }

            var transactionDetailsDebitObj = new TransactionDetail
            {
                CreatedBy = _currentUserService.UserId,
                Created = DateTime.UtcNow,
                RecordStatusId = (int)EnumRecordStatus.Approved,
                TransactionId = transactionDataInsertResult.Entity.TransactionId,
                Debit = result.Amount,
                AccountInfoId = requestAccountInfo?.AccountInfoId
            };

            await _context.TransactionDetails.AddAsync(transactionDetailsDebitObj);
        }

        private async Task UpdateTransactionRequestAsync(TransactionRequest transactionRequest, EntityEntry<Transaction> transactionDataInsertResult)
        {
            transactionRequest.RecordStatusId = (int)EnumRecordStatus.Approved;
            transactionRequest.ApprovedDate = transactionRequest.Modified = DateTime.UtcNow;
            transactionRequest.ApprovedBy = _currentUserService.UserId;
            transactionRequest.ModifiedBy = _currentUserService.UserId;
            transactionRequest.TransactionId = transactionDataInsertResult.Entity.TransactionId;

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
