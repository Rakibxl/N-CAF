using Architecture.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Core.Repository.Context.FluentAPIMapping
{
    public class ProfAssetInfoConfiguration : IEntityTypeConfiguration<ProfAssetInfo>
    {
        public void Configure(EntityTypeBuilder<ProfAssetInfo> assetInfo)
        {
            // Prof Asset Info
            assetInfo.HasKey(bs => bs.AssetInfoId);
            assetInfo.HasOne(v => v.ProfBasicInfo).WithMany(m => m.ProfAssetInfos).HasForeignKey(f => f.ProfileId).OnDelete(DeleteBehavior.Cascade);

            assetInfo.Property(bs => bs.NumberOfAsset).IsRequired();
            assetInfo.Property(bs => bs.EquivalentMoneyMax);
            assetInfo.Property(bs => bs.EquivalentMoneyMin);
            assetInfo.Property(bs => bs.MoneyAverage).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            assetInfo.Property(bs => bs.OwnershipPercentage).HasColumnType("decimal(5,2)").HasDefaultValue(0.0);
            assetInfo.Property(bs => bs.OwnerFromDate).HasColumnType("Date").IsRequired();
            assetInfo.Property(bs => bs.RentAmount).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            assetInfo.Property(bs => bs.TaxAmount).HasColumnType("decimal(10,2)").HasDefaultValue(0.0);
            assetInfo.Property(bs => bs.UseAblePercentage).HasColumnType("decimal(5,2)").HasDefaultValue(0.0);
            assetInfo.Property(bs => bs.AnyRestrictionByGovt).HasMaxLength(100);
            assetInfo.Property(bs => bs.CityName).HasMaxLength(100);
            assetInfo.Property(bs => bs.Created).ValueGeneratedOnAddOrUpdate().HasComputedColumnSql("GetUtcDate()");

        }
    }
}
