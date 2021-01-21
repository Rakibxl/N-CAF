using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class JobInfoConfiguration : IEntityTypeConfiguration<JobInfo>
    {
        public void Configure(EntityTypeBuilder<JobInfo> jobInfo)
        {
            jobInfo.HasKey(bs => bs.JobInfoId);
            jobInfo.Property(bs => bs.Title).HasMaxLength(250).IsRequired();
            jobInfo.Property(bs => bs.Description).HasMaxLength(250).IsRequired(false);
            jobInfo.Property(bs => bs.StartDate).HasColumnType("Date").IsRequired();
            jobInfo.Property(bs => bs.EndDate).HasColumnType("Date").IsRequired();
            jobInfo.Property(bs => bs.IsCommon).HasDefaultValue(false);
            jobInfo.Property(bs => bs.OperatorTimeFrame).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            jobInfo.Property(bs => bs.IsHighlighted).HasDefaultValue(false);
            jobInfo.Property(bs => bs.VideoLink).HasMaxLength(250).IsRequired(false);
            jobInfo.Property(bs => bs.DocumentLink).HasMaxLength(250).IsRequired(false);
            jobInfo.Property(bs => bs.ChildAgeMin).HasDefaultValue(0);
            jobInfo.Property(bs => bs.ChildAgeMax).IsRequired(false);
            jobInfo.Property(bs => bs.ISEEMin).IsRequired(false);
            jobInfo.Property(bs => bs.ISEEMax).IsRequired(false);
            jobInfo.Property(bs => bs.ISEEClassTypeId).IsRequired(false);
            jobInfo.Property(bs => bs.IsPregnant).HasDefaultValue(false);
            jobInfo.Property(bs => bs.NumberOfChild).IsRequired(false);
            jobInfo.Property(bs => bs.DaysToExpairJobContract).IsRequired(false);
            jobInfo.Property(bs => bs.DaysToBeExpairedResidencePermit).IsRequired(false);
            jobInfo.Property(bs => bs.IsEligibleForUnlimitedResidencePermit).HasDefaultValue(false);
            jobInfo.Property(bs => bs.IsEligibleForCityzenShipApply).HasDefaultValue(false);
            jobInfo.Property(bs => bs.HasUnlimitedResidencePermit).HasDefaultValue(false);
            jobInfo.Property(bs => bs.IsEligibleForUnlimitedResidencePermit).HasDefaultValue(false);
            jobInfo.Property(bs => bs.DaysToBeExpairedPassport).IsRequired(false);


            //jobInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            //jobInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
        }
    }
}
