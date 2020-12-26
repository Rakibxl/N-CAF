using Architecture.BLL.Services.Interfaces;
using Architecture.Web.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Architecture.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Architecture.Web.Controllers.Job
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/JobInfo")]
    public class JobInfoController : BaseController
    {
        private readonly IJobInformationService jobInfoService;

        public JobInfoController(IJobInformationService jobInfoService)
        {
            this.jobInfoService = jobInfoService;
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
        public async Task<IActionResult> CreateOrUpdate([FromBody] JobInformation model)
        {
            return await ModelValidation(async () =>
            {
                var result = await jobInfoService.AddOrUpdate(model);
                return OkResult(result);
            });
        }

        [HttpGet("GetJob")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await jobInfoService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetById/{jobInfoId}")]
        public async Task<IActionResult> GetById(int jobInfoId)
        {
            try
            {
                var result = await jobInfoService.GetById(jobInfoId);
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
