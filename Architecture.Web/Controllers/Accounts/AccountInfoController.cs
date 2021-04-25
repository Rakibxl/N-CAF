using Architecture.BLL.Services.Interfaces.Accounts;
using Architecture.Core.Entities.Accounts;
using Architecture.Web.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Web.Controllers.Accounts
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/AddressInfo")]
    public class AccountInfoController : BaseController
    {
        private readonly IAccountInfoService accountInfoService;

        public AccountInfoController(IAccountInfoService accountInfoService)
        {
            this.accountInfoService = accountInfoService;
        }
               

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] AccountInfo model)
        {
            return await ModelValidation(async () =>
            {
                var result = await accountInfoService.AddOrUpdate(model);
                return OkResult(result);
            });
        }

        [HttpGet("GetAllAccountInfo")]
        public async Task<IActionResult> GetAllAccountInfo()
        {
            try
            {
                var result = await accountInfoService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetById/{accountInfoId}")]
        public async Task<IActionResult> GetById(int accountInfoId)
        {
            try
            {
                var result = await accountInfoService.GetById(accountInfoId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }


        [HttpDelete("DeleteById/{accountInfoId}")]
        public async Task<IActionResult> DeleteById(int accountInfoId)
        {
            try
            {
                var result = await accountInfoService.Delete(accountInfoId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
