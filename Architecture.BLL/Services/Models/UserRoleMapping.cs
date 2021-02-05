using Architecture.Core.Common.Enums;
using Architecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Architecture.BLL.Services
{
    public class UserRoleMapping
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public EnumApplicationRoleStatus Status { get; set; }
        public int? BranchInfoId { get; set; }
        public string BranchLocation { get; set; }
    }
}