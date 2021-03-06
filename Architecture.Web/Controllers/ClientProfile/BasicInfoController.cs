using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Web.Controllers.Common;
using Architecture.Web.Core;
using Architecture.Web.Models.ClientProfile;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Architecture.Web.Controllers.BasicInfo
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/BasicInfo")]
    public class BasicInfoController : BaseController
    {
        private readonly IBasicInfoService _basicInfoService;
        //private readonly UserManager<ApplicationUser> _userManager;

        public BasicInfoController(IBasicInfoService basicInfoService
            //, UserManager<ApplicationUser> userManager
            )
        {
            _basicInfoService = basicInfoService;
            //_userManager = userManager;
        }

        [HttpGet("GetBasicInfos")]
        public async Task<IActionResult> GetBasicInfos()
        {
            try
            {
                var result = await _basicInfoService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetCurrentUserBasicInfo")]
        public async Task<IActionResult> GetCurrentUserBasicInfo()
        {
            try
            {
                var result = await _basicInfoService.GetCurrentUserBasicInfo();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetBasicInfo")]
        public async Task<IActionResult> GetBasicInfo(int profileId)
        {
            try
            {
                var result = new ProfBasicInfo();               
                result = await _basicInfoService.GetById(profileId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        
        [HttpGet("GetByEmailId/{emailId}")]
        public async Task<IActionResult> GetByEmailId(string emailId)
        {
            try
            {
                var result = new ProfBasicInfo();               
                result = await _basicInfoService.GetByEmailId(emailId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] ProfBasicInfo model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationResult(ModelState);
            }

            try
            {
                var uId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var UserId = (uId != null && uId != string.Empty) ? Guid.Parse(uId) : Guid.Empty;

                if (model.ProfileId > 0)
                {
                    model.ModifiedBy = UserId;
                    model.Modified = DateTime.UtcNow;
                }
                else
                {
                    model.RefId = UserId;
                    model.CreatedBy = UserId;
                    model.Created = DateTime.UtcNow;
                }


                var result = await _basicInfoService.AddOrUpdate(model);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}