namespace Architecture.Core.Entities.LU
{
    public class RecordStatus
    {
        public int RecordStatusId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
