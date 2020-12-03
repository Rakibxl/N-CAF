using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Web.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web.Controllers.ClientProfile
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/InsuranceInfo")]
    public class InsuranceInfoController : BaseController
    {
        private readonly IInsuranceInfoService insuranceInfoService;

        public InsuranceInfoController(IInsuranceInfoService insuranceInfoService)
        {
            this.insuranceInfoService = insuranceInfoService;
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
        public async Task<IActionResult> CreateOrUpdate([FromBody] ProfInsuranceInfo model)
        {
            return await ModelValidation(async () =>
            {
                var result = await insuranceInfoService.AddOrUpdate(model);
                return OkResult(result);
            });
        }

        [HttpGet("Profile/{profileId}")]
        public async Task<IActionResult> GetInsuranceByProfileId(int profileId)
        {
            try
            {
                var result =await insuranceInfoService.GetAll(profileId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

           [HttpGet("GetById/{profileId}/{insuranceInfoId}")]
        public async Task<IActionResult> GetById(int profileId, int insuranceInfoId)
        {
            try
            {
                var result = await insuranceInfoService.GetById(profileId, insuranceInfoId);
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
