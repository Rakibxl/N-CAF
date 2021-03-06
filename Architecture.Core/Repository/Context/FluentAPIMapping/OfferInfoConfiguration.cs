using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class OfferInfoConfiguration : IEntityTypeConfiguration<OfferInfo>
    {
        public void Configure(EntityTypeBuilder<OfferInfo> offerInfo)
        {
            offerInfo.HasKey(dd => dd.OfferInfoId);
            //offerInfo.HasOne(v => v.JobInfo).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);
            //delegationInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfDelegationInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            offerInfo.Property(bs => bs.JobId).IsRequired();
            offerInfo.Property(bs => bs.ProfileId).IsRequired();
            offerInfo.Property(bs => bs.ReceiptSrc).HasMaxLength(200);
            //offerInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            //offerInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
        }
    }
}