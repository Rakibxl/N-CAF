using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
   public class ProfHouseRentInfo : Auditable
    {
        public int HouseRentInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public DateTime? ContractDate { get; set; }
        public int? ContractTypeId { get; set; }
        public virtual ContractType ContractType { get; set; }
        public int? HouseTypeId { get; set; }
        public virtual HouseType HouseType { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal MonthlyRentAmount { get; set; }
        public decimal ServiceChargeAmount { get; set; }
        public string RegistrationInfo { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string RegistrationOffice { get; set; }
        public string RegistrationCode { get; set; }
        public string RegistrationNo { get; set; }
        public string RegistrationCity { get; set; }
        public bool? IsJoined { get; set; }
        public decimal SharePercent { get; set; }
        public string FoglioNo { get; set; }
        public string PartiocellaNo { get; set; }
        public string SubNo { get; set; }
        public string SectionNo { get; set; }
        public int? HouseCategoryId { get; set; }
        public virtual HouseCategory HouseCategory { get; set; }
        public string Zona { get; set; }
        public string MicroZona { get; set; }
        public string Consistenza { get; set; }
        public string SuperficieCatastale { get; set; }
        public string Rendita { get; set; }
        public string NotaioInfo { get; set; }
        public bool? HasLoan { get; set; }
        public int? LoanStatusTypeId { get; set; }
        public virtual LoanStatusType LoanStatusType { get; set; }
        public DateTime? LoanStartDate { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public int? LoanInterestTypeId { get; set; }
        public virtual LoanInterestType LoanInterestType { get; set; }
        public int? LoanPeriod { get; set; }
        public bool IsRentByOwner { get; set; }
        public decimal RentAmount { get; set; }

    }
}
