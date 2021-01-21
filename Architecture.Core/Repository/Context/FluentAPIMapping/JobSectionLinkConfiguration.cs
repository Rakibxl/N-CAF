using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class JobSectionLinkConfiguration : IEntityTypeConfiguration<JobSectionLink>
    {
        public void Configure(EntityTypeBuilder<JobSectionLink> jobSectionLink)
        {
            jobSectionLink.HasKey(bs => bs.JobSectionLinkId);
            jobSectionLink.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            jobSectionLink.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
        }
    }
}
