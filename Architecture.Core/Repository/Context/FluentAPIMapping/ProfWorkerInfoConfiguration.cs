using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfWorkerInfoConfiguration : IEntityTypeConfiguration<ProfWorkerInfo>
    {
        public void Configure(EntityTypeBuilder<ProfWorkerInfo> workerInfo)
        {
            // Prof worker Info
            workerInfo.HasKey(bs => bs.WorkerInfoId);
            workerInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfWorkerInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            workerInfo.Property(bs => bs.Name).HasMaxLength(100).IsRequired();
            workerInfo.Property(bs => bs.SurName).HasMaxLength(100).IsRequired();
            workerInfo.Property(bs => bs.TaxCode).HasMaxLength(100).IsRequired();
            workerInfo.Property(bs => bs.ContractNumber).HasMaxLength(100).IsRequired();
            workerInfo.Property(bs => bs.MonthlySalary).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            //workerInfo.Property(bs => bs.StartDate).HasColumnType("Date").IsRequired();
            //workerInfo.Property(bs => bs.EndDate).HasColumnType("Date").IsRequired();
            workerInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            workerInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
