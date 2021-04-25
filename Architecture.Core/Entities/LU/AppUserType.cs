namespace Architecture.Core.Entities.LU
{
    public class AppUserType
    {
        public int AppUserTypeId { get; set; }
        public string AppUserTypeTitle { get; set; }
        public bool VisibleForAdmin { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
