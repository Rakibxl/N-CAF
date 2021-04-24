using Architecture.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities.Accounts
{
   public class TransactionDetail:Auditable
    {
        public int TransactionDetailId { get; set; }
        public int TransactionId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
