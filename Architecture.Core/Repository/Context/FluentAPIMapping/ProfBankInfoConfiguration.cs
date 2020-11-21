using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfBankInfoConfiguration : IEntityTypeConfiguration<ProfBankInfo>
    {
        public void Configure(EntityTypeBuilder<ProfBankInfo> bankInfo)
        {
            // Prof Bank Info
            bankInfo.HasKey(bs => bs.BankInfoId);
            bankInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfBankInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);
            bankInfo.Property(bs => bs.BranchName).HasMaxLength(100);
            bankInfo.Property(bs => bs.AccountNumber).HasMaxLength(100);
            bankInfo.Property(bs => bs.SwiftNumber).HasMaxLength(100);
            bankInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            bankInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
