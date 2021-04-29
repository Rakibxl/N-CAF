using Architecture.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities.Accounts
{
  public class Transaction:Auditable
    {
        public int TransactionId { get; set; }
        public string TransactionPurpose { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public Guid? ApprovedBy { get; set; }
        public bool IsAutoAccounting { get; set; }
        public Decimal Amount { get; set; }
        public virtual List<TransactionDetail> TransactionDetail { get; set; }
    }
}
