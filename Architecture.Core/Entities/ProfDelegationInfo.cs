using System;
using Architecture.Core.Entities.Core;

namespace Architecture.Core.Entities
{
    public class ProfDelegationInfo : Auditable
    {
        public int DelegationInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TaxCode { get; set; }
        public string RefNo { get; set; }
        public string Purpose { get; set; }
        public DateTime DocumentIssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string IssuedBy { get; set; }
        public string Status { get; set; }

    }
}
