using Architecture.Core.Common.Enums;
using Architecture.Core.Entities;
using Architecture.Mappings;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Web.Models.ClientProfile
{
    public class ProfBasicInfoModel : IMapFrom<ProfBasicInfo>
    {
        public int ProfileId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string TaxCode { get; set; }
        public DateTime? TaxCodeStartDate { get; set; }
        public DateTime? TaxCodeEndDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public int? GenderId { get; set; }
        public int? MaritalStatusId { get; set; }
        [Required]
        public string Email { get; set; }
        public string PostalElectronicCertificate { get; set; }
        public string CityOfBirth { get; set; }
        public string StateOfBirth { get; set; }
        public string BirthStateCode { get; set; }
        public int? NationalityId { get; set; }
        public string CitizenStateCode { get; set; }
        public string EyesColorId { get; set; }
        public decimal? Height { get; set; }
        public string ZipCode { get; set; }
        public int? MotiveTypeId { get; set; }
        public string CityOfResidence { get; set; }
        public string StateOfResidence { get; set; }
        public int? OccupationTypeId { get; set; }
        public int? OccupationPositionId { get; set; }
        public bool? HasUnEmployedCertificate { get; set; }
        public DateTime? UnEmployedCertificateIssuesDate { get; set; }
        public bool? HasAnyUnEmployedFacility { get; set; }
        public int? ContractTypeId { get; set; }
        public decimal? YearlyIncome { get; set; }
        
        #region house info
        public bool? IsRentHouse { get; set; }
        public int? HowManyHouseRent { get; set; }
        public bool? IsHouseOwner { get; set; }
        public string HouseCountryName { get; set; }
        public string HouseCityName { get; set; }
        public bool? HasVehicle { get; set; }
        public string CarSerialNumber { get; set; }
        public string CarNumberPlate { get; set; }
        public bool? HasVehicleInsurance { get; set; }
        public bool? IsCompanyOwner { get; set; }
        public bool? HasWorker { get; set; }
        public string DigitalVatCode { get; set; }
        public bool? HasAppliedForCitizenship { get; set; }
        public string RequestTypeOfApplicant { get; set; }
        public string ApplicationFor { get; set; }
        public int? BranchInfoId { get; set; }
        #endregion


        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProfBasicInfoModel, ProfBasicInfo>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name.Trim()));
            profile.CreateMap<ProfBasicInfo, ProfBasicInfoModel>();
        }

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<ProfBasicInfo, ProfBasicInfoModel>()
        //        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Trim()))
        //        .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Trim()));
        //}
    }
}