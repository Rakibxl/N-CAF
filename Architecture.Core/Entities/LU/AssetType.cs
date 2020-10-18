namespace Architecture.Core.Entities.LU
{
    public class AssetType
    {
        public int AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
