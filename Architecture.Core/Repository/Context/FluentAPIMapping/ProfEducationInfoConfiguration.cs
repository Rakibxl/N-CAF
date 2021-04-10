using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfEducationInfoConfiguration : IEntityTypeConfiguration<ProfEducationInfo>
    {
        public void Configure(EntityTypeBuilder<ProfEducationInfo> educationInfo)
        {
            // Prof Education Info
            educationInfo.HasKey(bs => bs.EducationInfoId);
            educationInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfEducationInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);
            educationInfo.Property(bs => bs.InstitutionName).HasMaxLength(100).IsRequired();
            //educationInfo.Property(bs => bs.StartYear).HasColumnType("Date").IsRequired();
            //educationInfo.Property(bs => bs.EndYear).HasColumnType("Date").IsRequired();
            educationInfo.Property(bs => bs.UniversityAddress).HasMaxLength(500);
            educationInfo.Property(bs => bs.ActivitiesAndSocieties).HasMaxLength(500);
            educationInfo.Property(bs => bs.Result).HasMaxLength(100);
            educationInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            educationInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
