namespace Architecture.Core.Entities.LU
{
    public class JobType
    {
        public int JobTypeId { get; set; }
        public string JobTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
