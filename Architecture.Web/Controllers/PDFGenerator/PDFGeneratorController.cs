using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces;
using Architecture.Web.Controllers.Common;
using Architecture.Web.Core;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Architecture.Web.Controllers.PDFGenerator
{
    //[Authorize]
    //[ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class PDFGeneratorController : BaseController
    {
        private readonly IPDFGeneratorService _pdfGeneratorService;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public PDFGeneratorController(
            IPDFGeneratorService pdfGeneratorService,
            IOptionsSnapshot<AppSettings> appOptions,
            IMapper mapper)
        {
            this._pdfGeneratorService = pdfGeneratorService;
            this._appSettings = appOptions.Value;
            this._mapper = mapper;
        }

        [HttpGet("get-pdf")]
        //[Authorize(Permissions.Users.ListView)]
        public async Task<IActionResult> GetPDF()
        {
            try
            {
                var result = await _pdfGeneratorService.GetAllAsync();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}