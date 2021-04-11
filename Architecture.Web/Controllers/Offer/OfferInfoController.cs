using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetMyProgressOffer")]
        public async Task<IActionResult> ProgressOffer()
        {
            try
            {
                var result = await OfferInfoService.GetMyProgressOffer();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("GetCurrentOffer/{profileId}")]
        public IActionResult GetCurrentStatusById(int profileId)
        {
            try
            {
                var result =  OfferInfoService.GetCurrentStatusById(profileId);
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

        [HttpGet("OperatorProgressOffer")]
        public async Task<IActionResult> OperatorProgressOffer()
        {
            try
            {
                var result = await OfferInfoService.GetOperatorProgressOffer();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("OperatorCompletedOffer")]
        public async Task<IActionResult> OperatorCompletedOffer()
        {
            try
            {
                var result = await OfferInfoService.GetOperatorCompletedOffer();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        [HttpGet("OperatorPendingOffer")]
        public async Task<IActionResult> OperatorPendingOffer()
        {
            try
            {
                var result = await OfferInfoService.GetOperatorPendingOffer();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("OperatorOfferAcceptRequest/{offerInfoId}")]
        public async Task<IActionResult> OperatorOfferAcceptRequest(int offerInfoId)
        {
            try
            {
                var result = await OfferInfoService.OperatorOfferAcceptRequest(offerInfoId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        
        [HttpGet("OperatorOfferRevertRequest/{offerInfoId}")]
        public async Task<IActionResult> OperatorOfferRevertRequest(int offerInfoId)
        {
            try
            {
                var result = await OfferInfoService.OperatorAcceptedOfferRevertRequest(offerInfoId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        } 
        
        [HttpGet("OperatorOfferStatusChange")]
        public async Task<IActionResult> OperatorOfferStatusChange(int profileId, int offerInfoId, string status)
        {
            try
            {
                var result = await OfferInfoService.OperatorChangeOfferStatusRequest(profileId, offerInfoId, status);
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
            var uId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var UserId = (uId != null && uId != string.Empty) ? Guid.Parse(uId) : Guid.Empty;

            if (model.OfferInfoId > 0)
            {
                model.ModifiedBy = UserId;
                model.Modified = DateTime.Now;
            }
            else
            {
                model.CreatedBy = UserId;
                model.Created = DateTime.Now;
                model.Modified = DateTime.Now;
            }

            return await ModelValidation(async () =>
            {
                var result = await OfferInfoService.AddOrUpdate(model);
                return OkResult(result);
            });
        }
    }
}
