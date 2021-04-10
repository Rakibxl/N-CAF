using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
   public class ProfFamilyInfo: Auditable
    {
        public int FamilyInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? RelationTypeId { get; set; }
        public virtual RelationType RelationType { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string TaxCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int? OccupationTypeId { get; set; }
        public virtual OccupationType OccupationType { get; set; }
        public int? NationlityId { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual Nationality PreviousNationality { get; set; }
        public int? PreviousNationalityId { get; set; }
        public int? ResidenceScopeId { get; set; }
        public virtual ResidenceScope ResidenceScope { get; set; }
        public bool IsDependent { get; set; } = false;
        public decimal DependentPercentage { get; set; }
        public bool IsDisabled { get; set; }
        public decimal DisabledPercentage { get; set; }
        public decimal YearlyIncome { get; set; }
        public bool IsAppliedForCitizenship { get; set; } = false;
        public string ApplicationCode { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string ApplicationCity { get; set; }
        public string ApplicationPlacedAddress { get; set; }
        public string ApplicationFileNumber { get; set; }
        public DateTime? ApplicationPlacedDate { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int? ProvinceId { get; set; }
        public virtual Province Province { get; set; }

    }
}
