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
using System.Collections.Generic;

namespace Architecture.Web.Controllers.PromotionalBanners
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/app/examples")]
    public class ExamplesAppController : BaseController
    {
        private readonly IExampleService _exampleService;
        private readonly IMapper _mapper;

        public ExamplesAppController(
            IExampleService exampleService,
            IMapper mapper)
        {
            this._exampleService = exampleService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {                
                var result = await _exampleService.GetAllActiveAsync();
                var queryResult = _mapper.Map<IList<Example>, IList<ExampleModel>>(result);
                return OkResult(queryResult);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }            
        }
    }
}
