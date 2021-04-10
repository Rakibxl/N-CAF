using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfAddressInfoConfiguration : IEntityTypeConfiguration<ProfAddressInfo>
    {
        public void Configure(EntityTypeBuilder<ProfAddressInfo> addressInfo)
        {
            // Prof Address Info
            addressInfo.HasKey(bs => bs.AddressInfoId);
            addressInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfAddressInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            addressInfo.Property(bs => bs.RoadName).HasMaxLength(100).IsRequired();
            addressInfo.Property(bs => bs.RoadNo).HasMaxLength(100);
            addressInfo.Property(bs => bs.BuildingNo).HasMaxLength(100).IsRequired();
            addressInfo.Property(bs => bs.FloorNo).HasMaxLength(100);
            addressInfo.Property(bs => bs.AppartmentNo).HasMaxLength(100);
            addressInfo.Property(bs => bs.CityName).HasMaxLength(100).IsRequired();
            //addressInfo.Property(bs => bs.Province).HasMaxLength(100).IsRequired();
            addressInfo.Property(bs => bs.PostalCode).HasMaxLength(100).IsRequired();
            addressInfo.Property(bs => bs.State).HasMaxLength(100).IsRequired();
            //addressInfo.Property(bs => bs.StartDate).HasColumnType("Date").IsRequired();
            //addressInfo.Property(bs => bs.EndDate).HasColumnType("Date").IsRequired();
            addressInfo.Property(bs => bs.Modified).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");
            addressInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
