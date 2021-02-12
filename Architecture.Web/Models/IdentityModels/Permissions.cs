
namespace Architecture.Web.Models.IdentityModels
{
    public static class Permissions
    {
        public const string SuperAdmin = "Permissions.SuperAdmin";

        public static class Branches
        {
            public const string ListView = "Permissions.Branches.ListView";
            public const string DetailsView = "Permissions.Branches.DetailsView";
            public const string Create = "Permissions.Branches.Create";
            public const string Edit = "Permissions.Branches.Edit";
            public const string Delete = "Permissions.Branches.Delete";
        }

        public static class Users
        {
            public const string ListView = "Permissions.Users.ListView";
            public const string DetailsView = "Permissions.Users.DetailsView";
            public const string Create = "Permissions.Users.Create";
            public const string Edit = "Permissions.Users.Edit";
            public const string Delete = "Permissions.Users.Delete";
        }

        public static class UserRoles
        {
            public const string ListView = "Permissions.UserRoles.ListView";
            public const string DetailsView = "Permissions.UserRoles.DetailsView";
            public const string Create = "Permissions.UserRoles.Create";
            public const string Edit = "Permissions.UserRoles.Edit";
            //public const string CreateOrEdit = "Permissions.UserRoles.CreateOrEdit";
            public const string Delete = "Permissions.UserRoles.Delete";
        }

        public static class UserRoleMapping
        {
            public const string ListView = "Permissions.UserRoleMapping.ListView";
            public const string DetailsView = "Permissions.UserRoleMapping.DetailsView";
            public const string Create = "Permissions.UserRoleMapping.Create";
            public const string Edit = "Permissions.UserRoleMapping.Edit";
            //public const string CreateOrEdit = "Permissions.UserRoles.CreateOrEdit";
            public const string Delete = "Permissions.UserRoleMapping.Delete";
        }
    }
}