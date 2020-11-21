using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
   public class ProfFamilyInfoConfiguration : IEntityTypeConfiguration<ProfFamilyInfo>
    {       
        public void Configure(EntityTypeBuilder<ProfFamilyInfo> familyInfo)
        {
            // Prof Family Info
                familyInfo.HasKey(bs => bs.FamilyInfoId);
                familyInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfFamilyInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

                familyInfo.Property(bs => bs.Name).HasMaxLength(100).IsRequired();
                familyInfo.Property(bs => bs.SurName).HasMaxLength(100).IsRequired();
                familyInfo.Property(bs => bs.DateOfBirth).HasColumnType("Date").IsRequired();
                familyInfo.Property(bs => bs.TaxCode).HasMaxLength(100);
                familyInfo.Property(bs => bs.PlaceOfBirth).HasMaxLength(100);
                familyInfo.Property(bs => bs.PhoneNumber).HasMaxLength(100);
                familyInfo.Property(bs => bs.DependentPercentage).HasColumnType("decimal(3,2)").HasDefaultValue(0.0);
                familyInfo.Property(bs => bs.DisabledPercentage).HasColumnType("decimal(3,2)").HasDefaultValue(0.0);
                familyInfo.Property(bs => bs.YearlyIncome).HasColumnType("decimal(8,2)").HasDefaultValue(0.0);
                familyInfo.Property(bs => bs.ApplicationCode).HasMaxLength(100);
                familyInfo.Property(bs => bs.ApplicationCity).HasMaxLength(100);
                familyInfo.Property(bs => bs.ApplicationPlacedAddress).HasMaxLength(500);
                familyInfo.Property(bs => bs.ApplicationFileNumber).HasMaxLength(100);               
                familyInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
                familyInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
        }
    }
}
