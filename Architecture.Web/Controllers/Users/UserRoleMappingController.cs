﻿using System;
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
    [Route("api/v{v:apiVersion}/userRoleMapping")]
    public class UserRoleMappingController : BaseController
    {
        private IApplicationUserRoleMappingService _applicationUserRoleMappingService;
        private readonly IMapper _mapper;

        public UserRoleMappingController(
            IApplicationUserRoleMappingService applicationUserRoleMappingService,
            IMapper mapper)
        {
            this._applicationUserRoleMappingService = applicationUserRoleMappingService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] UserRoleQuery query)
        {
            try
            {
                var result = await _applicationUserRoleMappingService.GetAllAsync(query);
                var queryResult = _mapper.Map<QueryResult<ApplicationUserRole>, QueryResult<UserRoleModel>>(result);
                return OkResult(queryResult);
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
    }
}