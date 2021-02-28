using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces;
using Architecture.Web.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web.Controllers.Offer
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/OfferInfo")]
    public class OfferInfoController : BaseController
    {
        private readonly IOfferInfoService OfferInfoService;
        public OfferInfoController(IOfferInfoService OfferInfoService)
        {
            this.OfferInfoService = OfferInfoService;
        }

        [HttpGet("GetMyOffer")]
        public async Task<IActionResult> GetMyOffer()
        {
            try
            {
                var result = await OfferInfoService.GetMyOffer();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
