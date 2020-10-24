namespace Architecture.Core.Entities.LU
{
    public class BankName
    {
        public int BankNameId { get; set; }
        public string BankDescription { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
