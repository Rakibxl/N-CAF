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
    [Route("api/v{v:apiVersion}/AddressInfo")]
    public class AddressInfoController : BaseController
    {
        private readonly IAddressInfoService addressInfoService;

        public AddressInfoController(IAddressInfoService addressInfoService)
        {
            this.addressInfoService = addressInfoService;
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
        public async Task<IActionResult> CreateOrUpdate([FromBody] ProfAddressInfo model)
        {
            return await ModelValidation(async () =>
            {
                var result = await addressInfoService.AddOrUpdate(model);
                return OkResult(result);
            });
        }

        [HttpGet("Profile/{profileId}")]
        public async Task<IActionResult> GetAddressByProfileId(int profileId)
        {
            try
            {
                var result =await addressInfoService.GetAll(profileId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetById/{profileId}/{addressInfoId}")]
        public async Task<IActionResult> GetById(int profileId, int addressInfoId)
        {
            try
            {
                var result = await addressInfoService.GetById(profileId, addressInfoId);
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
