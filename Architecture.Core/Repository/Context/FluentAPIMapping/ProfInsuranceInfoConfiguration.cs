using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfInsuranceInfoConfiguration : IEntityTypeConfiguration<ProfInsuranceInfo>
    {
        public void Configure(EntityTypeBuilder<ProfInsuranceInfo> insuranceInfo)
        {
            // Prof Insurance Info
            insuranceInfo.HasKey(bs => bs.InsuranceInfoId);
            insuranceInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfInsuranceInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);
            insuranceInfo.Property(bs => bs.InsuranceTitle).HasMaxLength(100).IsRequired();
            insuranceInfo.Property(bs => bs.InsuranceAmount).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            insuranceInfo.Property(bs => bs.InsuranceReturnPercentage).HasMaxLength(100);
            insuranceInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            insuranceInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
