namespace Architecture.Core.Entities.LU
{
    public class AppUserStatus
    {
        public int AppUserStatusId { get; set; }
        public string AppUserStatusTitle { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
