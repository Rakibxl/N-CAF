using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Architecture.Core.Entities.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Architecture.Core.Entities
{
   public class ProfBasicInfo: Auditable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TaxCode { get; set; }
        public DateTime? TaxCodeStartDate { get; set; }
        public DateTime? TaxCodeEndDate { get; set; }
        public string PhoneNumber { get; set; }
        public int? GenderId { get; set; }
        public int? MaritalStatusId { get; set; }
        public string Email { get; set; }
        public string PostalElectronicCertificate { get; set; }
        public string CityOfBirth { get; set; }
        public string StateOfBirth { get; set; }
        public string BirthStateCode { get; set; }
        public int? NationalityId { get; set; }
        public string CitizenStateCode { get; set; }
        public string EyesColorId { get; set; }
        public decimal Height { get; set; }
        public string ZipCode { get; set; }
        public int? MotiveTypeId { get; set; }
        public int? OccupationTypeId { get; set; }
        public int? OccupationPositionId { get; set; }
        public bool HasUnEmployedCertificate { get; set; }
        public DateTime? UnEmployedCertificateIssuesDate { get; set; }
        public bool HasAnyUnEmployedFacility { get; set; }
        public int? ContractTypeId { get; set; }
        public decimal YearlyIncome { get; set; }
        #region house info
        public Boolean IsRentHouse { get; set; }
        public int? HowManyHouseRent { get; set; }
        public bool IsHouseOwner { get; set; }
        public string HouseCountryName { get; set; }
        public string HouseCityName { get; set; }
        public bool HasVehicle { get; set; }
        public string CarSerialNumber { get; set; }
        public string CarNumberPlate { get; set; }
        public Boolean HasVehicleInsurance { get; set; }
        public bool IsCompanyOwner { get; set; }
        public bool HasWorker { get; set; }
        public string DigitalVatCode { get; set; }
        public bool HasAppliedForCitizenship { get; set; }
        public int? BranchId { get; set; }
        public virtual ICollection<ProfFamilyInfo> ProfFamilyInfos { get; set; }
        #endregion

    }
}
