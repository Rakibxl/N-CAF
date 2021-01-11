using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Web.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web.Controllers.ClientProfile
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/SectionLinkInfo")]
    public class SectionLinkController : BaseController
    {
        private readonly ISectionLinkService sectionLinkService;


        public SectionLinkController(ISectionLinkService sectionLinkService)
        {
            this.sectionLinkService = sectionLinkService;
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
        public async Task<IActionResult> CreateOrUpdate([FromBody] SectionLink model)
        {
            return await ModelValidation(async () =>
            {
                var result = await sectionLinkService.AddOrUpdate(model);
                return OkResult(result);
            });
        }

        [HttpGet("GetSection")]
        public async Task<IActionResult> GetSection()
        {
            try
            {
                
                var result = await sectionLinkService.GetAll();
                return OkResult(result);
               
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetById/{sectionlinkId}")]
        public async Task<IActionResult> GetById(int sectionlinkId)
        {
            try
            {
                var result = await sectionLinkService.GetById(sectionlinkId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("GetBySectionName/{sectionName}")]
        public async Task<IActionResult> GetBySectionName(string sectionName)
        {
            try
            {
                var result = await sectionLinkService.GetBySectionName(sectionName);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

    }
}
