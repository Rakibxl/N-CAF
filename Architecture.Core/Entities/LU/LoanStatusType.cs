namespace Architecture.Core.Entities.LU
{
    public class LoanStatusType
    {
        public int LoanStatusTypeId { get; set; }
        public string LoanStatusTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
