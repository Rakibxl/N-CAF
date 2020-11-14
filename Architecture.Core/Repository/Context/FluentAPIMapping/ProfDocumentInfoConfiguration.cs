using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfDocumentInfoConfiguration : IEntityTypeConfiguration<ProfDocumentInfo>
    {
        public void Configure(EntityTypeBuilder<ProfDocumentInfo> documentInfo)
        {
            // Prof Document Info
            documentInfo.HasKey(bs => bs.DocumentInfoId);
            documentInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfDocumentInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);
            documentInfo.Property(bs => bs.PurposeOfDocument).HasMaxLength(100).IsRequired();
            documentInfo.Property(bs => bs.IssuedBy).HasMaxLength(100);
            documentInfo.Property(bs => bs.IssuedDate).HasColumnType("Date").IsRequired();
            documentInfo.Property(bs => bs.ExpiryDate).HasColumnType("Date").IsRequired();
            documentInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            documentInfo.Property(bs => bs.Created).ValueGeneratedOnAdd().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
