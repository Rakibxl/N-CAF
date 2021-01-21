using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
   public class BranchInfoConfiguration : IEntityTypeConfiguration<BranchInfo>
    {
        public void Configure(EntityTypeBuilder<BranchInfo> branchInfo)
        {
            branchInfo.HasKey(bs => bs.BranchInfoId);
            //branchInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfbranchInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);
            branchInfo.Property(bs => bs.BranchLocation).HasMaxLength(100).IsRequired();
            branchInfo.Property(bs => bs.Address).HasMaxLength(100).IsRequired();
            branchInfo.Property(bs => bs.City).HasMaxLength(100).IsRequired();
            branchInfo.Property(bs => bs.ContactPerson).HasMaxLength(100).IsRequired();
            branchInfo.Property(bs => bs.ContactNumber).HasMaxLength(100).IsRequired();
            branchInfo.Property(bs => bs.AgreementStart).HasColumnType("Date");
            //branchInfo.Property(bs => bs.NumberOfUser).HasDefaultValue(false);
            branchInfo.Property(bs => bs.IsLocked).HasDefaultValue(false);
            branchInfo.Property(bs => bs.Note).HasMaxLength(500);
            branchInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            branchInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
        }
    }
}
