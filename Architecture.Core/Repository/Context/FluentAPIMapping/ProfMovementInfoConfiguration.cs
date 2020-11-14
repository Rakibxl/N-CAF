using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfMovementInfoConfiguration : IEntityTypeConfiguration<ProfMovementInfo>
    {
        public void Configure(EntityTypeBuilder<ProfMovementInfo> movementInfo)
        {
            // Prof Movement Info
            movementInfo.HasKey(bs => bs.MovementInfoId);
            movementInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfMovementInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            movementInfo.Property(bs => bs.Purpose).HasMaxLength(100);
            movementInfo.Property(bs => bs.Status).HasMaxLength(100);
            movementInfo.Property(bs => bs.StartDate).HasColumnType("Date").IsRequired();
            movementInfo.Property(bs => bs.EndDate).HasColumnType("Date").IsRequired();
            movementInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            movementInfo.Property(bs => bs.Created).ValueGeneratedOnAdd().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
