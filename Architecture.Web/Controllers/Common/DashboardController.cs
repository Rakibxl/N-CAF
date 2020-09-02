using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Architecture.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web.Controllers.Common
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/dashboard")]
    public class DashboardController : BaseController
    {
        private readonly IDashboardService _dashboardService;
        private readonly IMapper _mapper;

        public DashboardController(
            IDashboardService dashboardService,
            IMapper mapper)
        {
            _dashboardService = dashboardService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _dashboardService.GetDashboardDataAsync();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
