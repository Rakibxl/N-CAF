using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfHouseRentInfoConfiguration : IEntityTypeConfiguration<ProfHouseRentInfo>
    {
        public void Configure(EntityTypeBuilder<ProfHouseRentInfo> houserentInfo)
        {
            // Prof HouseRent Info
            houserentInfo.HasKey(bs => bs.HouseRentInfoId);
            houserentInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfHouseRentInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            houserentInfo.Property(bs => bs.ContractDate).HasColumnType("Date").IsRequired(false);
            //houserentInfo.Property(bs => bs.StartDate).HasColumnType("Date").IsRequired(false);
            //houserentInfo.Property(bs => bs.EndDate).HasColumnType("Date").IsRequired(false);

            houserentInfo.Property(bs => bs.MonthlyRentAmount).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            houserentInfo.Property(bs => bs.ServiceChargeAmount).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            houserentInfo.Property(bs => bs.RegistrationInfo).HasMaxLength(100);
            houserentInfo.Property(bs => bs.RegistrationDate).HasColumnType("Date").IsRequired(false);
            houserentInfo.Property(bs => bs.RegistrationOffice).HasMaxLength(100);
            houserentInfo.Property(bs => bs.RegistrationCode).HasMaxLength(100);
            houserentInfo.Property(bs => bs.RegistrationNo).HasMaxLength(100);
            houserentInfo.Property(bs => bs.RegistrationCity).HasMaxLength(100);
            houserentInfo.Property(bs => bs.SharePercent).HasColumnType("decimal(5,2)").HasDefaultValue(0.0);
            houserentInfo.Property(bs => bs.FoglioNo).HasMaxLength(100);
            houserentInfo.Property(bs => bs.PartiocellaNo).HasMaxLength(100);
            houserentInfo.Property(bs => bs.SubNo).HasMaxLength(100);
            houserentInfo.Property(bs => bs.SectionNo).HasMaxLength(100);
            houserentInfo.Property(bs => bs.Zona).HasMaxLength(100);
            houserentInfo.Property(bs => bs.MicroZona).HasMaxLength(100);
            houserentInfo.Property(bs => bs.Consistenza).HasMaxLength(100);
            houserentInfo.Property(bs => bs.SuperficieCatastale).HasMaxLength(100);
            houserentInfo.Property(bs => bs.Rendita).HasMaxLength(100);
            houserentInfo.Property(bs => bs.NotaioInfo).HasMaxLength(100);
            //houserentInfo.Property(bs => bs.LoanStartDate).HasColumnType("Date").IsRequired(false);
            houserentInfo.Property(bs => bs.LoanAmount).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            houserentInfo.Property(bs => bs.PaidAmount).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            houserentInfo.Property(bs => bs.RentAmount).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);

        }
    }
}
