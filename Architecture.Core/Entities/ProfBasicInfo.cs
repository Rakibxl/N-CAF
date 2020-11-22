using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Architecture.Core.Entities.Core;
using System.ComponentModel.DataAnnotations.Schema;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
   public class ProfBasicInfo: Auditable
    {
        public int ProfileId { get; set; }
        public Guid RefId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TaxCode { get; set; }
        public DateTime? TaxCodeStartDate { get; set; }
        public DateTime? TaxCodeEndDate { get; set; }
        public string PhoneNumber { get; set; }
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int? MaritalStatusId { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public string Email { get; set; }
        public string PostalElectronicCertificate { get; set; }
        public string CityOfBirth { get; set; }
        public string StateOfBirth { get; set; }
        public string BirthStateCode { get; set; }
        public int? NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }
        public string CitizenStateCode { get; set; }
        public int? EyeColorId { get; set; } 
        public int? testData { get; set; }
        public virtual EyeColor EyeColor { get; set; }
        public decimal Height { get; set; }
        public string ZipCode { get; set; }
        public int? MotiveTypeId { get; set; }
        public virtual MotiveType MotiveType { get; set; }
        public int? OccupationTypeId { get; set; }
        public virtual OccupationType OccupationType { get; set; }
        public int? OccupationPositionId { get; set; }
        public virtual OccupationPosition OccupationPosition { get; set; }
        public bool HasUnEmployedCertificate { get; set; }
        public DateTime? UnEmployedCertificateIssuesDate { get; set; }
        public bool HasAnyUnEmployedFacility { get; set; }
        public int? ContractTypeId { get; set; }
        public virtual ContractType ContractType { get; set; }
        public decimal YearlyIncome { get; set; }
        public bool IsPregnant { get; set; }
        public DateTime? ExpectedBabyBirthDate { get; set; }

        #region house info
        public bool IsRentHouse { get; set; }
        public int? HowManyHouseRent { get; set; }
        public bool IsHouseOwner { get; set; }
        public string HouseCountryName { get; set; }
        public string HouseCityName { get; set; }
        public bool HasVehicle { get; set; }
        public string CarSerialNumber { get; set; }
        public string CarNumberPlate { get; set; }
        public bool HasVehicleInsurance { get; set; }
        public bool IsCompanyOwner { get; set; }
        public bool HasWorker { get; set; }
        public string DigitalVatCode { get; set; }
        public bool HasAppliedForCitizenship { get; set; }
        public int? BranchId { get; set; }
        public virtual ICollection<ProfFamilyInfo> ProfFamilyInfos { get; set; }
        public virtual ICollection<ProfAddressInfo> ProfAddressInfos { get; set; }
        public virtual ICollection<ProfAssetInfo> ProfAssetInfos { get; set; }
        public virtual ICollection<ProfBankInfo> ProfBankInfos { get; set; }
        public virtual ICollection<ProfLegalInfo> ProfLegalInfos { get; set; }
        public virtual ICollection<ProfInsuranceInfo> ProfInsuranceInfos { get; set; }
        public virtual ICollection<ProfWorkerInfo> ProfWorkerInfos { get; set; }
        public virtual ICollection<ProfDelegationInfo> ProfDelegationInfos { get; set; }
        public virtual ICollection<ProfISEEInfo> ProfISEEInfos { get; set; }
        public virtual ICollection<ProfIncomeInfo> ProfIncomeInfos { get; set; }
        public virtual ICollection<ProfMovementInfo> ProfMovementInfos { get; set; }
        public virtual ICollection<ProfDocumentInfo> ProfDocumentInfos { get; set; }
        public virtual ICollection<ProfEducationInfo> ProfEducationInfos { get; set; }
        public virtual ICollection<ProfOccupationInfo> ProfOccupationInfos { get; set; }
        public virtual ICollection<ProfHouseRentInfo> ProfHouseRentInfos { get; set; }
        #endregion
    }
}
