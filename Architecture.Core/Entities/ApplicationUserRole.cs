using System;
using Microsoft.AspNetCore.Identity;

namespace Architecture.Core.Entities
{
    public class ApplicationUserRole : IdentityUserRole<Guid>
    {
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }
}