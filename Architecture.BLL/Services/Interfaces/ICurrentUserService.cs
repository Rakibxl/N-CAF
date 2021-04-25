using System;

namespace Architecture.BLL.Services.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        public int UserTypeId { get; }
        public string Useremail { get; }
        bool IsAuthenticated { get; }
        public string BranchInfoId { get; }
        public int CurrentUserProfileId { get; }
        public string UserName { get; }
    }
}
