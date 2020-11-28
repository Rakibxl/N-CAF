using Architecture.Core.Common.Enums;
using Architecture.Core.Entities;
using Architecture.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Architecture.Web.Models
{
    public class UserRoleModel : IMapFrom<ApplicationRole>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public EnumApplicationRoleStatus? Status { get; set; }
        public IList<string> Permissions { get; set; }

        public UserRoleModel()
        {
            this.Permissions = new List<string>();
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationRole, UserRoleModel>();
        }
    }

    public class SaveUserRoleModel : IMapFrom<ApplicationRole>
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public EnumApplicationRoleStatus Status { get; set; }
        public IList<string> Permissions { get; set; }

        public SaveUserRoleModel()
        {
            this.Permissions = new List<string>();
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveUserRoleModel, ApplicationRole>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name.Trim()));
            profile.CreateMap<ApplicationRole, SaveUserRoleModel>();
        }
    }

    public class ApplicationUserRoleModel
    {
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Role { get; set; }
    }
}