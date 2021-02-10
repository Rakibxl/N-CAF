using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Architecture.BLL.Services.Interfaces;
using Architecture.Web.Controllers.Common;
using Architecture.Web.Models;
using Architecture.Web.Models.IdentityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Architecture.BLL.Services;

namespace Architecture.Web.Controllers.Users
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/userRoleMapping")]
    public class UserRoleMappingController : BaseController
    {
        private IApplicationUserRoleMappingService _applicationUserRoleMappingService;

        public UserRoleMappingController(IApplicationUserRoleMappingService applicationUserRoleMappingService)
        {
            this._applicationUserRoleMappingService = applicationUserRoleMappingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserRoleQuery query)
        {
            try
            {
                var result = await _applicationUserRoleMappingService.GetAllAsync(query);

                var AppUserTypeId = GetClaimValue("AppUserTypeId");
                if (AppUserTypeId == "1")
                {

                }
                else if (AppUserTypeId == "2")
                {
                    var BranchInfoId = GetClaimValue("BranchInfoId");
                    if (BranchInfoId != null && !string.IsNullOrEmpty(BranchInfoId))
                    {
                        result = result.Where(ex => ex.BranchInfoId != null && ex.BranchInfoId.Value == int.Parse(BranchInfoId)).ToList();
                    }
                    else
                    {
                        result = new List<UserRoleMapping>();
                    }
                }
                else
                {
                    result = new List<UserRoleMapping>();
                }
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ApplicationUserRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationResult(ModelState);
            }

            try
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Id = model.UserId
                };

                var res = await _applicationUserRoleMappingService.AddAsync(user, model.Role);
                return OkResult(res);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ApplicationUserRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationResult(ModelState);
            }

            try
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Id = model.UserId
                };

                var res = await _applicationUserRoleMappingService.AddAsync(user, model.Role);
                return OkResult(res);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
