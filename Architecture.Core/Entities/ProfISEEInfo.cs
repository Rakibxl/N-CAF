using System;
using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
    public class ProfISEEInfo : Auditable
    {
        public int ISEEInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? ISEEClassTypeId { get; set; }
        public virtual ISEEClassType ISEEClassType { get; set; }
        public decimal ISEEValue { get; set; }
        public decimal Point { get; set; }
        public decimal ISEEFamilyIncome { get; set; }
        public decimal ISPAmount { get; set; }
        public decimal ISEAmount { get; set; }
        public decimal ISRAmount { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime? SubmittedDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
