namespace Architecture.Core.Entities.LU
{
    public class JobDeliveryType
    {
        public int JobDeliveryTypeId { get; set; }
        public string JobDeliveryTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
