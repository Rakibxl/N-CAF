using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfOccupationInfoConfiguration : IEntityTypeConfiguration<ProfOccupationInfo>
    {
        public void Configure(EntityTypeBuilder<ProfOccupationInfo> occupationInfo)
        {
            // Prof Occupation Info
            occupationInfo.HasKey(bs => bs.OccupationInfoId);
            occupationInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfOccupationInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            occupationInfo.Property(bs => bs.JobHour).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            //occupationInfo.Property(bs => bs.ContractStartDate).HasColumnType("Date").IsRequired();
            //occupationInfo.Property(bs => bs.ContractEndDate).HasColumnType("Date").IsRequired();
            occupationInfo.Property(bs => bs.CompanyName).HasMaxLength(100).IsRequired();
            occupationInfo.Property(bs => bs.VATNo).HasMaxLength(100);
            occupationInfo.Property(bs => bs.LegalCompanyAddress).HasMaxLength(500);
            occupationInfo.Property(bs => bs.OfficeAddress).HasMaxLength(500);
            occupationInfo.Property(bs => bs.BranchAddress).HasMaxLength(500);
            occupationInfo.Property(bs => bs.ChamberOfCommerceRegNo).HasMaxLength(100);
            occupationInfo.Property(bs => bs.ChamberOfCommerceCityName).HasMaxLength(100);
            occupationInfo.Property(bs => bs.REANo).HasMaxLength(100);
            occupationInfo.Property(bs => bs.ATECONo).HasMaxLength(100);
            occupationInfo.Property(bs => bs.SCIANo).HasMaxLength(100);
            occupationInfo.Property(bs => bs.SCIACityName).HasMaxLength(100);
            occupationInfo.Property(bs => bs.PercentageOfShare).HasColumnType("decimal(5,2)").HasDefaultValue(0.0);
            occupationInfo.Property(bs => bs.NotaioInfo).HasMaxLength(100);
            occupationInfo.Property(bs => bs.CompanyRepresentative).HasMaxLength(100);

            occupationInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            occupationInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
