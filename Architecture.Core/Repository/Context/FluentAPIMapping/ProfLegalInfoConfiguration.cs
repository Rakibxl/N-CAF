using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfLegalInfoConfiguration : IEntityTypeConfiguration<ProfLegalInfo>
    {
        public void Configure(EntityTypeBuilder<ProfLegalInfo> legalInfo)
        {
            // Prof Legal Info
            legalInfo.HasKey(bs => bs.LegalInfoId);
            legalInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfLegalInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            legalInfo.Property(bs => bs.CityName).HasMaxLength(100).IsRequired();
            legalInfo.Property(bs => bs.RefNo).HasMaxLength(100);
            legalInfo.Property(bs => bs.Reason).HasMaxLength(100);
            legalInfo.Property(bs => bs.Note).HasMaxLength(500);
            legalInfo.Property(bs => bs.StartDate).HasColumnType("Date").IsRequired();
            legalInfo.Property(bs => bs.EndDate).HasColumnType("Date").IsRequired();
            legalInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            legalInfo.Property(bs => bs.Created).ValueGeneratedOnAdd().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
