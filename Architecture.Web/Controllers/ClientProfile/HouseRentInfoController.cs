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
    [Route("api/v{v:apiVersion}/HouseRentInfo")]
    public class HouseRentInfoController : BaseController
    {
        private readonly IHouseRentInfoService houseRentInfoService;

        public HouseRentInfoController(IHouseRentInfoService houseRentInfoService)
        {
            this.houseRentInfoService = houseRentInfoService;
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
        public async Task<IActionResult> CreateOrUpdate([FromBody] ProfHouseRentInfo model)
        {

            try
            {
                return await ModelValidation(async () =>
                {
                    var result = await houseRentInfoService.AddOrUpdate(model);
                    return OkResult(result);
                });
            }
            catch (Exception ex)
            {

                return ExceptionResult(ex);
            }
        }

        [HttpGet("Profile/{profileId}")]
        public async Task<IActionResult> GetHouseRentByProfileId(int profileId)
        {
            try
            {
                var result =await houseRentInfoService.GetAll(profileId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetById/{profileId}/{houserentInfoId}")]
        public async Task<IActionResult> GetById(int profileId, int houserentInfoId)
        {
            try
            {
                var result = await houseRentInfoService.GetById(profileId, houserentInfoId);
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
