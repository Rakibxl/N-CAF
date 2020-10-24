using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
   public class ProfOccupationInfo : Auditable
    {
        public int OccupationInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? JobTypeId { get; set; }
        public virtual JobType JobType { get; set; }
        public decimal JobHour { get; set; }
        public int? ContractTypeId { get; set; }
        public virtual ContractType ContractType { get; set; }
        public DateTime? ContractStartDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public string CompanyName { get; set; }
        public string VATNo { get; set; }
        public string LegalCompanyAddress { get; set; }
        public string OfficeAddress { get; set; }
        public string BranchAddress { get; set; }
        public string ChamberOfCommerceRegNo { get; set; }
        public string ChamberOfCommerceCityName { get; set; }
        public string REANo { get; set; }
        public string ATECONo { get; set; }
        public string SCIANo { get; set; }
        public string SCIACityName { get; set; }
        public bool? IsShareHolder { get; set; }
        public decimal PercentageOfShare { get; set; }
        public string NotaioInfo { get; set; }
        public string CompanyRepresentative { get; set; }

    }
}
