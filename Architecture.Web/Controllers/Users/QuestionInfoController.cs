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
    [Route("api/v{v:apiVersion}/QuestionInfo")]
    public class QuestionInfoController : BaseController
    {
        private readonly IQuestionService questionInfoService;

        private readonly IBasicInfoService basicInfoService;

        public QuestionInfoController(IQuestionService questionInfoService, IBasicInfoService basicInfoService)
        {
            this.questionInfoService = questionInfoService;
            this.basicInfoService = basicInfoService;
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
        public async Task<IActionResult> CreateOrUpdate([FromBody] QuestionInfo model)
        {
            return await ModelValidation(async () =>
            {
                var result = await questionInfoService.AddOrUpdate(model);
                return OkResult(result);
            });
        }

        [HttpGet("GetQuestion")]
        public async Task<IActionResult> GetQuestion()
        {
            try
            {
                
                var x = await basicInfoService.GetBasicWithIncludeAll();

                var result = await questionInfoService.GetAll();
                return OkResult(result);
                
               
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetById/{questionInfoId}")]
        public async Task<IActionResult> GetById(int questionInfoId)
        {
            try
            {
                var result = await questionInfoService.GetById(questionInfoId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

       
        [HttpGet("GetUserQuestion")]
        public async Task<IActionResult> GetUserQuestion()
        {
            try
            {
                var result = await questionInfoService.GetUserQuestion();
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
