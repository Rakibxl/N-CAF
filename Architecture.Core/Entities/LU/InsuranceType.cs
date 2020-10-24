namespace Architecture.Core.Entities.LU
{
    public class InsuranceType
    {
        public int InsuranceTypeId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
