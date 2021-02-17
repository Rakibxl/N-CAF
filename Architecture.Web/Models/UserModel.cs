using Architecture.Core.Common.Enums;
using Architecture.Core.Entities;
using Architecture.Mappings;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Architecture.Web.Models
{
    public class UserModel : IMapFrom<ApplicationUser>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? GenderId { get; set; }
        public string Gender { get; set; }
        public int? AppUserTypeId { get; set; }
        public string AppUserType { get; set; }
        public int? BranchInfoId { get; set; }
        public string BranchLocation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ImageUrl { get; set; }
        public Guid? UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public EnumApplicationUserStatus? Status { get; set; }
        public string OperatorKeywordIds { get; set; }
        public List<int> OperatorBranches { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, UserModel>()
                .ForMember(dest => dest.BranchLocation, opt => opt.MapFrom(src => src.BranchInfo.BranchLocation))
                .ForMember(dest => dest.AppUserType, opt => opt.MapFrom(src => src.AppUserType.AppUserTypeTitle))
                .ForMember(dest => dest.OperatorBranches, opt => opt.MapFrom(src => src.OperatorBranches.Select(dd => dd.BranchInfoId).ToList()))
                .ForMember(dest => dest.UserRoleName, opt => opt.MapFrom(src =>
                    src.UserRoles.Any() ? (src.UserRoles.Select(ur => ur.Role).FirstOrDefault() != null ?
                    src.UserRoles.Select(ur => ur.Role.Name).FirstOrDefault() : null) : null))
                .ForMember(dest => dest.UserRoleId, opt => opt.MapFrom(src =>
                    src.UserRoles.Any() ? (src.UserRoles.Select(ur => ur.Role).FirstOrDefault() != null ?
                    src.UserRoles.Select(ur => ur.RoleId).FirstOrDefault() : (Guid?)null) : (Guid?)null));
        }
    }

    public class SaveUserModel : IMapFrom<ApplicationUser>
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string SurName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public int? GenderId { get; set; }
        public int? AppUserTypeId { get; set; }
        public int? BranchInfoId { get; set; }
        [Required]
        public Guid UserRoleId { get; set; }
        public string OperatorKeywordIds { get; set; }
        public List<int> OperatorBranches { get; set; }

        //public string UserName { get; set; }
        //public string ImageUrl { get; set; }
        //public IFormFile ImageFile { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SaveUserModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(s => s.Email.Trim()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(s => s.Email.Trim()))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(s => s.Name.Trim()))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber.Trim()));
            profile.CreateMap<ApplicationUser, SaveUserModel>()
                .ForMember(dest => dest.UserRoleId, opt => opt.MapFrom(s => s.UserRoles.Any() ? 
                    s.UserRoles.FirstOrDefault().RoleId : Guid.Empty));
        }
    }
}