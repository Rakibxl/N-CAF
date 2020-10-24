namespace Architecture.Core.Entities.LU
{
    public class AddressType
    {
        public int AddressTypeId { get; set; }
        public string AddressTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
