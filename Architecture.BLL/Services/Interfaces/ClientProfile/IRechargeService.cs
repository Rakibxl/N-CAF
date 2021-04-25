using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities.Accounts;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IRechargeService
    {
        Task<TransactionRequest> AddOrUpdateAsync(TransactionRequest transactionRequest);
        Task<IEnumerable<TransactionRequest>> GetAllAsync();
        Task<bool> ApprovePendingRechargeAsync(int transactionRequestId);
        Task<bool> RejectPendingRechargeAsync(int transactionRequestId);
    }
}
