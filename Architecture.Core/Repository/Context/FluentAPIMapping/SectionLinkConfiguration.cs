using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class SectionLinkConfiguration : IEntityTypeConfiguration<SectionLink>
    {
        public void Configure(EntityTypeBuilder<SectionLink> sectionlink)
        {
            sectionlink.HasKey(bs => bs.SectionLinkId);
            sectionlink.Property(bs => bs.Title).HasMaxLength(250).IsRequired();
            sectionlink.Property(bs => bs.ActionLink).HasMaxLength(100).IsRequired();
            sectionlink.Property(bs => bs.Remarks).HasMaxLength(100).IsRequired(false);
            sectionlink.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            sectionlink.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
        }
    }
}
