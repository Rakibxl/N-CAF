using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;
using System;

namespace Architecture.Core.Entities
{
    public class ProfInsuranceInfo : Auditable
    {
        public int InsuranceInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? InsuranceTypeId { get; set; }
        public virtual InsuranceType InsuranceType { get; set; }
        public string InsuranceTitle { get; set; }
        public decimal InsuranceAmount { get; set; }
        public string InsuranceReturnPercentage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
