using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities;
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
                var x = "Laboni";
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int offerInfoId)
        {
            try
            {
                var result = await OfferInfoService.GetById(offerInfoId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] OfferInfo model)
        {
            return await ModelValidation(async () =>
            {
                var result = await OfferInfoService.AddOrUpdate(model);
                return OkResult(result);
            });
        }
    }
}
