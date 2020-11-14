using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfDelegationInfoConfiguration : IEntityTypeConfiguration<ProfDelegationInfo>
    {
        public void Configure(EntityTypeBuilder<ProfDelegationInfo> delegationInfo)
        {
            // Prof delegation Info
            delegationInfo.HasKey(bs => bs.DelegationInfoId);
            delegationInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfDelegationInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            delegationInfo.Property(bs => bs.Name).HasMaxLength(100).IsRequired();
            delegationInfo.Property(bs => bs.SurName).HasMaxLength(100).IsRequired();
            delegationInfo.Property(bs => bs.DateOfBirth).HasColumnType("Date").IsRequired();
            delegationInfo.Property(bs => bs.TaxCode).HasMaxLength(100).IsRequired();
            delegationInfo.Property(bs => bs.RefNo).HasMaxLength(100);
            delegationInfo.Property(bs => bs.Purpose).HasMaxLength(100);
            delegationInfo.Property(bs => bs.DocumentIssueDate).HasColumnType("Date").IsRequired();
            delegationInfo.Property(bs => bs.ExpiryDate).HasColumnType("Date").IsRequired();
            delegationInfo.Property(bs => bs.IssuedBy).HasMaxLength(100);
            delegationInfo.Property(bs => bs.Status).HasMaxLength(100);
            delegationInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            delegationInfo.Property(bs => bs.Created).ValueGeneratedOnAdd().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
