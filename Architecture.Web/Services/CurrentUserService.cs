using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using Architecture.BLL.Services.Interfaces;

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
            IsAuthenticated = httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated??false;
        }

        public Guid UserId { get; }
        public int UserTypeId { get; }
        public string Useremail { get; }
        public bool IsAuthenticated { get; }
    }
}
