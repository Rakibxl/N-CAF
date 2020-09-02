using System;
using System.Threading.Tasks;
using Architecture.Core.Entities.NotMapped;
using Architecture.BLL.Services.Interfaces;
using Architecture.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Architecture.Web.Controllers.Common;
using Architecture.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Architecture.Web.Core;
using Microsoft.Extensions.Options;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Architecture.Core.Common.Enums;

namespace Architecture.Web.Controllers.PromotionalBanners
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/examples")]
    public class ExamplesController : BaseController
    {
        private readonly IExampleService _exampleService;
        private readonly IPhotoStorage _photoStorage;
        private readonly IMapper _mapper;

        public ExamplesController(
            IExampleService exampleService,
            IPhotoStorage photoStorage,
            IMapper mapper)
        {
            this._exampleService = exampleService;
            this._photoStorage = photoStorage;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ExampleQuery query)
        {
            try
            {                
                var result = await _exampleService.GetAllAsync(query);
                var queryResult = _mapper.Map<QueryResult<Example>, QueryResult<ExampleModel>>(result);
                return OkResult(queryResult);
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
                var promotionalBanner = await _exampleService.GetByIdAsync(id);
                var result = _mapper.Map<Example, ExampleModel>(promotionalBanner);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] SaveExampleModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationResult(ModelState);
            }

            try
            {
                var promotionalBanner = _mapper.Map<SaveExampleModel, Example>(model);
                if(model.ImageFile != null)
                {
                    this._photoStorage.IsValidImage(model.ImageFile);
                    var fileName = model.Name + "_" + Guid.NewGuid().ToString();
                    var imageUrl = await _photoStorage.SaveImageAsync(model.ImageFile, fileName, EnumFileUploadFolderCode.Example);
                    promotionalBanner.ImageUrl = imageUrl;
                }
                var result = await _exampleService.AddAsync(promotionalBanner);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] SaveExampleModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationResult(ModelState);
            }

            try
            {
                var promotionalBanner = _mapper.Map<SaveExampleModel, Example>(model);
                if (model.ImageFile != null)
                {
                    this._photoStorage.IsValidImage(model.ImageFile);
                    var fileName = model.Name + "_" + Guid.NewGuid().ToString();
                    var imageUrl = await _photoStorage.SaveImageAsync(model.ImageFile, fileName, EnumFileUploadFolderCode.Example);
                    promotionalBanner.ImageUrl = imageUrl;
                }
                await _exampleService.UpdateAsync(promotionalBanner);
                return OkResult(true);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _exampleService.DeleteAsync(id);
                return OkResult(true);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
