using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
   public class ProfAssetInfo : Auditable
    {
        public int AssetInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? AssetTypeId { get; set; }
        public virtual AssetType AssetType { get; set; }
        public int NumberOfAsset { get; set; }
        public int EquivalentMoneyMax { get; set; }
        public int EquivalentMoneyMin { get; set; }
        public decimal MoneyAverage { get; set; }
        public int OwnerTypeId { get; set; }
        public virtual OwnerType OwnerType { get; set; }
        public decimal OwnershipPercentage { get; set; }
        public DateTime? OwnerFromDate { get; set; }
        public decimal RentAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal UseAblePercentage { get; set; }
        public string AnyRestrictionByGovt { get; set; }
        public string CityName { get; set; }
        public string Note { get; set; }

    }
}
