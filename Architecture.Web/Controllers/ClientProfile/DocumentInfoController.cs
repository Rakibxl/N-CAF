using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Web.Controllers.Common;
using Architecture.Web.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Architecture.Web.Controllers.ClientProfile
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/DocumentInfo")]
    public class DocumentInfoController : BaseController
    {
        private readonly IDocumentInfoService documentInfoService;

        public DocumentInfoController(IDocumentInfoService documentInfoService)
        {
            this.documentInfoService = documentInfoService;
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
        public async Task<IActionResult> CreateOrUpdate([FromBody] ProfDocumentInfo model)
        {
            return await ModelValidation(async () =>
            {
                var result = await documentInfoService.AddOrUpdate(model);
                return OkResult(result);
            });
        }
        [HttpPost("document/save")]
        public async Task<IActionResult> SaveDocument()
        {
            var entity = SaveFile();
            return await ModelValidation(async () =>
            {
                var result = await documentInfoService.AddOrUpdate(entity);
                return OkResult(result);
            });

        }
        private ProfDocumentInfo  SaveFile()
        {
            string file_key = "doc";
            var entity = new ProfDocumentInfo();
            try
            {
                var model = HttpContext.Request.Form.ToDictionary(x => x.Key, x => x.Value.ToString());

                entity = JsonConvert.DeserializeObject<ProfDocumentInfo>(model["model"]);

               var files = HttpContext.Request.Form.Files.Count > 0 ?
                        HttpContext.Request.Form.Files : null;

                if (files != null && files[file_key] != null)
                {
                    string folder = entity.ProfileId.ToString() + "/" + entity.DocumentTypeId;
                   var  name =  FileHandler.SaveFile(files[file_key], folder, entity.DocumentName);
                }
                return entity;
            }
            catch (Exception ex)
            {
             
                throw ex;
            }

        }
        [HttpGet("Profile/{profileId}")]
        public async Task<IActionResult> GetDocumentByProfileId(int profileId)
        {
            try
            {
                var result =await documentInfoService.GetAll(profileId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetById/{profileId}/{documentInfoId}")]
        public async Task<IActionResult> GetById(int profileId, int documentInfoId)
        {
            try
            {
                var result = await documentInfoService.GetById(profileId, documentInfoId);
                string folder = profileId.ToString() + "/" + result.DocumentTypeId;
                var urls = FileHandler.GetFiles(folder);
                result.Urls= urls;
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
