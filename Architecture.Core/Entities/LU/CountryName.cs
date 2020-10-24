namespace Architecture.Core.Entities.LU
{
    public class CountryName
    {
        public int CountryNameId { get; set; }
        public string CountryDescription { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
