using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Web.Controllers.Common;
using Architecture.Web.Core;
using Architecture.Web.Models.ClientProfile;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Architecture.Web.Controllers.BasicInfo
{
    //[Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/BasicInfo")]
    public class BasicInfoController : BaseController
    {
        private readonly IBasicInfoService _basicInfoService;

        public BasicInfoController(IBasicInfoService basicInfoService)
        {
            _basicInfoService = basicInfoService;
        }

        [HttpGet("GetBasicInfo")]
        public async Task<IActionResult> GetBasicInfo()
        {
            try
            {
                var basicInfoId = 2;
                var result = await _basicInfoService.GetById(basicInfoId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        var result = "";
        //        return OkResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] ProfBasicInfo model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationResult(ModelState);
            }

            try
            {
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