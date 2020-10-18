namespace Architecture.Core.Entities.LU
{
    public class WorkerType
    {
        public int WorkerTypeId { get; set; }
        public string WorkerTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
