using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;
using System;

namespace Architecture.Core.Entities.Accounts
{
    public class TransactionRequest : Auditable
    {
        public int TransactionRequestId { get; set; }
        public string Purpose { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public Guid? RequestBy { get; set; }
        public int? TransactionId { get; set; }
        public int? PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get;set;}
        public string PaymentReceivedBy { get; set; }
        public DateTime? PaymentReceivedDate { get; set; }
        public Decimal Amount { get; set; }
    }
}
