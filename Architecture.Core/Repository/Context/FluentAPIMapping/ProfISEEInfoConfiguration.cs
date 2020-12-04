using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfISEEInfoConfiguration : IEntityTypeConfiguration<ProfISEEInfo>
    {
        public void Configure(EntityTypeBuilder<ProfISEEInfo> iseeInfo)
        {
            // Prof ISEE Info
            iseeInfo.HasKey(bs => bs.ISEEInfoId);
            iseeInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfISEEInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            iseeInfo.Property(bs => bs.ISEEValue).HasColumnType("decimal(10,2)").IsRequired();
            iseeInfo.Property(bs => bs.Point).HasColumnType("decimal(10,2)").IsRequired();
            iseeInfo.Property(bs => bs.ISEEFamilyIncome).HasColumnType("decimal(10,2)").IsRequired();
            iseeInfo.Property(bs => bs.ISPAmount).HasColumnType("decimal(10,2)").IsRequired();
            iseeInfo.Property(bs => bs.ISEAmount).HasColumnType("decimal(10,2)").IsRequired();
            iseeInfo.Property(bs => bs.ISRAmount).HasColumnType("decimal(10,2)").IsRequired();
            iseeInfo.Property(bs => bs.IdentificationNumber).HasMaxLength(100).IsRequired();
            iseeInfo.Property(bs => bs.SubmittedDate).HasColumnType("Date").IsRequired();
            iseeInfo.Property(bs => bs.DeliveryDate).HasColumnType("Date").IsRequired();
            iseeInfo.Property(bs => bs.ExpiryDate).HasColumnType("Date").IsRequired();

            iseeInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            iseeInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
