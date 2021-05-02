using Architecture.BLL.Services.Models;
using Architecture.Core.Entities;
using Architecture.Core.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.Accounts
{
   public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAll();
        Task<IEnumerable<TransactionDetailVM>> GetPendingApproval();
        Task<Transaction> GetById(int transactionId);
        Task<Transaction> AddOrUpdate(Transaction transactionInfo);
        Task<string> Delete(int transactionId);
        Task<Transaction> CreateTransactionForOfferSubmit(OfferInfo offerInfo);
        Task<Transaction> CreateTransactionForAcceptOffer(OfferInfo offerInfo);
        Task<string> DeletedTransactionForRevertOffer(OfferInfo offerInfo);
        Task<string>CreateTransactionForCompletedOffer(OfferInfo offerInfo);
        Task<string> ApprovalRejectOperatorAmount(int transactionId, string status);
    }
}
