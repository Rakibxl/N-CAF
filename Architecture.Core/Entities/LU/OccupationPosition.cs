namespace Architecture.Core.Entities.LU
{
    public class OccupationPosition
    {
        public int OccupationPositionId { get; set; }
        public string OccupationPositionName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
