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

namespace Architecture.Web.Controllers.Users
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/roles")]
    public class RolesController : BaseController
    {
        private IApplicationRoleService _applicationRoleService;
        private readonly IMapper _mapper;

        public RolesController(
            IApplicationRoleService applicationRoleService,
            IMapper mapper)
        {
            this._applicationRoleService = applicationRoleService;
            this._mapper = mapper;
        }

        [HttpGet]
        //[Authorize(Permissions.UserRoles.ListView)]
        public async Task<IActionResult> Get([FromQuery] UserRoleQuery query)
        {
            try
            {
                var result = await _applicationRoleService.GetAllAsync(query);
                var queryResult = _mapper.Map<QueryResult<ApplicationRole>, QueryResult<UserRoleModel>>(result);
                var data = queryResult.Items.ToList();

                var AppUserTypeId = GetClaimValue("AppUserTypeId");
                if (AppUserTypeId == "2")
                {
                    data = data.Where(ex => ex.Name != "Super Admin").ToList();
                }
                else if (AppUserTypeId != "1")
                {
                    data = new List<UserRoleModel>();
                }
                return OkResult(data);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("{id}")]
        //[Authorize(Permissions.UserRoles.DetailsView)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var role = await _applicationRoleService.GetByIdAsync(id);
                var result = _mapper.Map<ApplicationRole, UserRoleModel>(role.ApplicationRole);
                result.Permissions = role.Permissions;
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] SaveUserRoleModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationResult(ModelState);
            }

            try
            {

                if (model.Id != Guid.Empty)
                {
                    var role = _mapper.Map<SaveUserRoleModel, ApplicationRole>(model);
                    await _applicationRoleService.UpdateAsync(role, model.Permissions);
                    return OkResult(true);
                }
                else
                {
                    var role = _mapper.Map<SaveUserRoleModel, ApplicationRole>(model);
                    var result = await _applicationRoleService.AddAsync(role, model.Permissions);
                    return OkResult(result);               
                };
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveUserRoleModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return ValidationResult(ModelState);

                var role = _mapper.Map<SaveUserRoleModel, ApplicationRole>(model);
                var result = await _applicationRoleService.AddAsync(role, model.Permissions);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] SaveUserRoleModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return ValidationResult(ModelState);

                var role = _mapper.Map<SaveUserRoleModel, ApplicationRole>(model);
                await _applicationRoleService.UpdateAsync(role, model.Permissions);
                return OkResult(true);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _applicationRoleService.DeleteAsync(id);
                return OkResult(true);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost("activeInactive/{id}")]
        public async Task<IActionResult> ActiveInactive(Guid id)
        {
            try
            {
                await _applicationRoleService.ActiveInactiveAsync(id);
                return OkResult(true);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("select")]
        public async Task<IActionResult> GetSelect()
        {
            try
            {
                var result = await _applicationRoleService.GetAllForSelectAsync();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
