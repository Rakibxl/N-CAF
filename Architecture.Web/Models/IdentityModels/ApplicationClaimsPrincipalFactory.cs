using Architecture.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Architecture.Web.Models.IdentityModels
{
    public class ApplicationClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public ApplicationClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager
            , RoleManager<ApplicationRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
                new Claim("Name", user.Name ?? string.Empty),
                new Claim("ImageUrl", user.ImageUrl ?? string.Empty)
            });

            return principal;
        }
    }
}