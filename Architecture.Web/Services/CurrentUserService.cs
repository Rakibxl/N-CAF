using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using Architecture.BLL.Services.Interfaces;
using System.Linq;

namespace Architecture.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            Guid.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out Guid value);
            UserId = value;
            UserTypeId = Int32.Parse(httpContextAccessor.HttpContext?.User?.FindFirst("AppUserTypeId").Value);
            Useremail = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            UserName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            IsAuthenticated = httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated??false;
            BranchInfoId = String.IsNullOrEmpty(httpContextAccessor.HttpContext?.User?.FindFirst("BranchInfoId")?.Value) ? "0" : httpContextAccessor.HttpContext?.User?.FindFirst("BranchInfoId")?.Value;
            CurrentUserProfileId = Int32.Parse(String.IsNullOrEmpty(httpContextAccessor.HttpContext?.User?.FindFirst("ProfileId")?.Value)?"0": httpContextAccessor.HttpContext?.User?.FindFirst("ProfileId")?.Value);
        }

        public Guid UserId { get; }
        public int UserTypeId { get; }
        public string Useremail { get; }
        public string UserName { get; }
        public bool IsAuthenticated { get; }
        public string BranchInfoId { get; }
        public int CurrentUserProfileId { get; }
    }
}
