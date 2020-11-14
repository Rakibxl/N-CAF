using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfIncomeInfoConfiguration : IEntityTypeConfiguration<ProfIncomeInfo>
    {
        public void Configure(EntityTypeBuilder<ProfIncomeInfo> incomeInfo)
        {
            // Prof Income Info
            incomeInfo.HasKey(bs => bs.IncomeInfoId);
            incomeInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfIncomeInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            incomeInfo.Property(bs => bs.YearlyIncome).HasColumnType("decimal(8,2)").IsRequired();
            incomeInfo.Property(bs => bs.MonthlyIncome).HasColumnType("decimal(8,2)").IsRequired();
            incomeInfo.Property(bs => bs.Year).HasColumnType("date").IsRequired();
            incomeInfo.Property(bs => bs.Month).HasColumnType("date").IsRequired();
            incomeInfo.Property(bs => bs.Document).HasMaxLength(100);
            incomeInfo.Property(bs => bs.Status).HasMaxLength(100);
            incomeInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            incomeInfo.Property(bs => bs.Created).ValueGeneratedOnAdd().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
