using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
    public class ProfBankInfo : Auditable
    {
        public int BankInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? BankNameId { get; set; }
        public virtual BankName BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public string SwiftNumber { get; set; }      
        public string Status { get; set; }

    }
}
    