using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities.Accounts
{
   public class AccountInfo:Auditable
    {
        public int AccountInfoId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string MasterId { get; set; }
        public int? AppUserTypeId { get; set; }
        public virtual AppUserType AppUserType { get; set; }
        public Guid? NotifyUserId { get; set; }

    }
}
