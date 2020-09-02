using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Common.Constants
{
    public static class ConstantsValue
    {
        public static UserRoleName UserRoleName => new UserRoleName();
        public static RolePermission RolePermission => new RolePermission();
    }

    public class UserRoleName
    {
        public string SuperAdmin => "SuperAdmin";
        public string Admin => "Admin";
        public string GeneralUser => "GeneralUser";
        public string AppUser => "AppUser";
    }

    public class RolePermission
    {
        public string Type => "Permission";
        public string Value => "Permissions.SuperAdmin";
    }
}
