namespace Architecture.Core.Entities.LU
{
    public class Nationality
    {
        public int NationalityId { get; set; }
        public string NationalityName { get; set; }
        public string NationalityCode { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
