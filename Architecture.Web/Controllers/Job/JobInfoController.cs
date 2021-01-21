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

        private readonly IJobSectionLinkService jobSectionLinkService;
        //public JobInfoController(IJobInformationService jobInfoService, IJobSectionLinkService jobSectionLinkService)
        //{
        //    this.jobInfoService = jobInfoService;
        //    this.jobSectionLinkService = jobSectionLinkService;
        //} 
        
        public JobInfoController( IJobSectionLinkService jobSectionLinkService)
        {
            //this.jobInfoService = jobInfoService;
            this.jobSectionLinkService = jobSectionLinkService;
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
        public async Task<IActionResult> CreateOrUpdate([FromBody] JobInfo model)
        {
            return await ModelValidation(async () =>
            {
                var jobSectionLinks = model.JobSectionLink;
                model.JobSectionLink = null;
               // var result = await jobInfoService.AddOrUpdate(model);
                //var jobSectionResult = await jobSectionLinkService.AddOrUpdateOrDelete(result.JobInfoId, jobSectionLinks);
                //var jobSectionResult = await jobSectionLinkService.AddOrUpdateOrDelete(1, jobSectionLinks);
                var jobSectionResult = await jobSectionLinkService.AddOrUpdateOrDelete(1, jobSectionLinks);
                //return OkResult(result);


                // save for job section link

                //string[] split = model.SectionList.Split(',');

                
                //foreach (string item in split)
                //{
                //    JobSectionLink jobSectionLink = new JobSectionLink();
                //    jobSectionLink.JobInfoId = model.JobInfoId;
                //    jobSectionLink.SectionNameId = Int32.Parse(item) ;
                //    var result2 = await jobSectionLinkService.AddOrUpdate(jobSectionLink);
                //}

                return OkResult("OK");

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
