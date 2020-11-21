using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Web.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web.Controllers.ClientProfile
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/EducationInfo")]
    public class EducationInfoController : BaseController
    {
        private readonly IEducationInfoService educationInfoService;

        public EducationInfoController(IEducationInfoService educationInfoService)
        {
            this.educationInfoService = educationInfoService;
        }

        [HttpGet("/Test")]
        public async Task<IActionResult> GetTest()
        {
            try
            {
                var result = "dfdsdfdsff";
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] ProfEducationInfo model)
        {            
            return await ModelValidation(async()=> {
                var result = await educationInfoService.AddOrUpdate(model);
                return OkResult(result);
            });
        }

        [HttpGet("Profile/{profileId}")]
        public async Task<IActionResult> GetEducationByProfileId(int profileId)
        {
            try
            {
                var result =await educationInfoService.GetAll(profileId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetTestData")]
        public async Task<IActionResult> GetTestData()
        {
            try
            {
                var result = "tstrrrggsdfdfdfd";
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = "Palash Kanti Habijabi";
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
