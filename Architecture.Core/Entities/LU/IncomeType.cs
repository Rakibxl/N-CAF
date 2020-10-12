namespace Architecture.Core.Entities.LU
{
    public class IncomeType
    {
        public int IncomeTypeId { get; set; }
        public string IncomeTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
