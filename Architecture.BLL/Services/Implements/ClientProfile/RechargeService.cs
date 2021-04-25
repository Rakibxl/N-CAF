using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities.Accounts;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class RechargeService : Repository<TransactionRequest>, IRechargeService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public RechargeService(ApplicationDbContext context, ICurrentUserService currentUserService) : base(context)
        {
            _context = context;
            _currentUserService = currentUserService;
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
                transactionRequest.CreatedBy = _currentUserService.UserId;

                result = await AddAsync(transactionRequest);
            }

            return result;
        }

        public async Task<IEnumerable<TransactionRequest>> GetAllAsync()
        {
            if (_currentUserService.UserTypeId == (int)EnumAppUserType.Client)
                return await GetAsync(x => x, x => x.CreatedBy == _currentUserService.UserId, x => x.OrderByDescending(y => y.Created));

            return await GetAsync(x => x, x => x.RecordStatusId == (int)EnumRecordStatus.WaitingforApproval, x => x.OrderByDescending(y => y.Created));
        }

        public async Task<bool> ApprovePendingRechargeAsync(int transactionRequestId)
        {
            TransactionRequest result = await GetByIdAsync(transactionRequestId);

            if (result != null)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    result.RecordStatusId = (int)EnumRecordStatus.Approved;
                    result.ApprovedDate = result.Modified = DateTime.UtcNow;
                    result.ApprovedBy = _currentUserService.UserId;
                    result.ModifiedBy = _currentUserService.UserId;

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

                    var transactionDetailsCreditObj = new TransactionDetail
                    {
                        CreatedBy = _currentUserService.UserId,
                        RecordStatusId = (int)EnumRecordStatus.Approved,
                        TransactionId = transactionDataInsertResult.Entity.TransactionId,
                        Credit = result.Amount,
                        AccountInfoId = result.TransactionRequestId,
                    };

                    await _context.TransactionDetails.AddAsync(transactionDetailsCreditObj);

                    var transactionDetailsDebitObj = new TransactionDetail
                    {
                        CreatedBy = _currentUserService.UserId,
                        RecordStatusId = (int)EnumRecordStatus.Approved,
                        TransactionId = transactionDataInsertResult.Entity.TransactionId,
                        Debit = result.Amount,
                        AccountInfoId = _currentUserService.UserId,
                    };
                    await _context.TransactionDetails.AddAsync(transactionDetailsDebitObj);

                    result.TransactionId = transactionDataInsertResult.Entity.TransactionId;
                    await UpdateAsync(result);

                    transaction.Commit();
                }
            }

            return true;
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
