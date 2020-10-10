namespace Architecture.Core.Entities.LU
{
    public class HouseType
    {
        public int HouseTypeId { get; set; }
        public string HouseTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
