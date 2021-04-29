using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.BLL.Services.Models
{
  public  class AccountInfoVM : Auditable
    {
        public int AccountInfoId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string MasterId { get; set; }
        public int? AppUserTypeId { get; set; }
        public virtual AppUserType AppUserType { get; set; }
        public decimal BalanceAmount { get; set; }
        public decimal ProgressAmount { get; set; }
    }
}
