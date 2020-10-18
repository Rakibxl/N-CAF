using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.BLL.Services.ClientProfile.Interfaces;
using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities;
using Architecture.Web.Controllers.Common;
using Architecture.Web.Core;
using Architecture.Web.Models.ClientProfile;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Architecture.Web.Controllers.ClientProfile
{
    //[Authorize]
    //[ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientProfileController : BaseController
    {
        private readonly IClientProfileService _clientProfileService;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public ClientProfileController(
            IClientProfileService clientProfileService,
            IOptionsSnapshot<AppSettings> appOptions,
            IMapper mapper)
        {
            this._clientProfileService = clientProfileService;
            this._appSettings = appOptions.Value;
            this._mapper = mapper;
        }

        //[HttpGet("get-pdf")]
        ////[Authorize(Permissions.Users.ListView)]
        //public IActionResult GeneratePDF()
        //{
        //    try
        //    {
        //        var result = _clientProfileService.GeneratePDF();
        //        return OkResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}

        [HttpPost("save-basic-info")]
        public async Task<IActionResult> SaveBasicInfo([FromBody] ProfBasicInfoModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return ValidationResult(ModelState);

                var basicInfo = _mapper.Map<ProfBasicInfoModel, ProfBasicInfo>(model);
                var result = await _clientProfileService.AddUpdate(basicInfo);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

    }
}