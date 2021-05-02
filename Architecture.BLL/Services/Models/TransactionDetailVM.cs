using Architecture.Core.Entities;
using Architecture.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.BLL.Services.Models
{
   public class TransactionDetailVM:Auditable
    {
        public int TransactionDetailId { get; set; }
        public int TransactionId { get; set; }
        public string TransactionPurpose { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public Decimal Amount { get; set; }
        public int? AccountInfoId { get; set; }
        public string CratedByName { get; set; }
        public int? OfferInfoId { get; set; }
        public OfferInfo OfferInfo { get; set; }
    }
}

