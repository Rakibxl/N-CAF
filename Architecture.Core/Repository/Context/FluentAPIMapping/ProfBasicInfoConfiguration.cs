using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
   public class ProfBasicInfoConfiguration: IEntityTypeConfiguration<ProfBasicInfo>
    {
        public void Configure(EntityTypeBuilder<ProfBasicInfo> basicInfo)
        {
            //Prof Basic Info
            basicInfo.HasKey(bs => bs.ProfileId);
            basicInfo.Property(bs => bs.Name).HasMaxLength(100).IsRequired();
            basicInfo.Property(bs => bs.SurName).HasMaxLength(100).IsRequired();
            basicInfo.Property(bs => bs.DateOfBirth).HasColumnType("Date").IsRequired();
            basicInfo.Property(bs => bs.TaxCode).HasMaxLength(100).IsRequired();
            basicInfo.Property(bs => bs.TaxCodeStartDate).IsRequired(false).HasColumnType("Date");
            basicInfo.Property(bs => bs.TaxCodeEndDate).HasColumnType("Date").IsRequired(false);
            basicInfo.Property(bs => bs.PhoneNumber).HasMaxLength(100).IsRequired();
            basicInfo.Property(bs => bs.GenderId).IsRequired(false);
            //basicInfo.Property(bs => bs.MaritalStatusId).HasMaxLength(100).IsRequired();
            basicInfo.Property(bs => bs.Email).HasMaxLength(100).IsRequired();
            basicInfo.Property(bs => bs.PostalElectronicCertificate).HasMaxLength(100);
            basicInfo.Property(bs => bs.CityOfBirth).HasMaxLength(100);
            basicInfo.Property(bs => bs.StateOfBirth).HasMaxLength(100);
            basicInfo.Property(bs => bs.BirthStateCode).HasMaxLength(100);
            //basicInfo.Property(bs => bs.NationalityId).HasMaxLength(100);
            basicInfo.Property(bs => bs.CitizenStateCode).HasMaxLength(100);
            //basicInfo.Property(bs => bs.EyesColorId).HasMaxLength(100);
            basicInfo.Property(bs => bs.Height).HasColumnType("decimal(3,2)").HasDefaultValue(0.0);
            basicInfo.Property(bs => bs.ZipCode).HasMaxLength(100);
            //basicInfo.Property(bs => bs.MotiveTypeId).HasMaxLength(100);
            //basicInfo.Property(bs => bs.OccupationTypeId).HasMaxLength(100);
            //basicInfo.Property(bs => bs.OccupationPositionId).HasMaxLength(100);
            basicInfo.Property(bs => bs.HasUnEmployedCertificate).HasDefaultValue(false);
            basicInfo.Property(bs => bs.UnEmployedCertificateIssuesDate).HasColumnType("Date").IsRequired(false);
            basicInfo.Property(bs => bs.HasAnyUnEmployedFacility).HasDefaultValue(false);
            //basicInfo.Property(bs => bs.ContractTypeId).HasMaxLength(100);
            basicInfo.Property(bs => bs.YearlyIncome).IsRequired(false).HasColumnType("decimal(8,2)").HasDefaultValue(0.0);
            basicInfo.Property(bs => bs.IsRentHouse).HasDefaultValue(false);
            basicInfo.Property(bs => bs.IsHouseOwner).HasDefaultValue(false);
            basicInfo.Property(bs => bs.HasVehicle).HasDefaultValue(false);
            basicInfo.Property(bs => bs.HasVehicleInsurance).HasDefaultValue(false);
            basicInfo.Property(bs => bs.IsCompanyOwner).HasDefaultValue(false);
            basicInfo.Property(bs => bs.HasWorker).HasDefaultValue(false);
            basicInfo.Property(bs => bs.HasAppliedForCitizenship).HasDefaultValue(false);
            basicInfo.Property(bs => bs.HouseCountryName).HasMaxLength(100);
            basicInfo.Property(bs => bs.HouseCityName).HasMaxLength(100);
            basicInfo.Property(bs => bs.CarSerialNumber).HasMaxLength(100);
            basicInfo.Property(bs => bs.CarNumberPlate).HasMaxLength(100);
            basicInfo.Property(bs => bs.HouseCountryName).HasMaxLength(100);
            basicInfo.Property(bs => bs.DigitalVatCode).HasMaxLength(100);
            basicInfo.Property(bs => bs.Modified).ValueGeneratedOnUpdate().HasComputedColumnSql("GetUtcDate()");
            basicInfo.Property(bs => bs.Created).ValueGeneratedOnAdd().HasComputedColumnSql("GetUtcDate()");
        }
    }
}
