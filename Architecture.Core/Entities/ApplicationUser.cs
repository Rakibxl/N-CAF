using System;
using System.Collections.Generic;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities.LU;
using Microsoft.AspNetCore.Identity;

namespace Architecture.Core.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int? GenderId { get; set; }
        public string ImageUrl { get; set; }
        public string LastPassword { get; set; }
        public DateTime? LastPassChangeDate { get; set; }
        public int? AppUserStatusId { get; set; }
        public AppUserStatus AppUserStatus { get; set; }
        public int? AppUserTypeId { get; set; }
        public AppUserType AppUserType { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }
        public bool IsLocked { get; set; }
        public int? BranchId { get; set; }
        //public BranchInfo BranchInfo { get; set; }

        public IList<ApplicationUserRole> UserRoles { get; set; }

        public ApplicationUser() : base()
        {
            this.IsLocked = false;
            this.UserRoles = new List<ApplicationUserRole>();
        }
    }
}