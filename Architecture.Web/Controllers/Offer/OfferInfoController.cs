using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities;
using Architecture.Web.Controllers.Common;
using Architecture.Web.Utilities;
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

        [HttpGet("GetMyOffer/{profileId}")]
        public async Task<IActionResult> GetMyOffer(int profileId)
        {
            try
            {
                var result = await OfferInfoService.GetMyOffer(profileId);
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

        [HttpGet("ClientProgressOffer/{profileId}")] 
        public async Task<IActionResult> ClientProgressOffer( int profileId)
        {
            try
            {
                var result = await OfferInfoService.GetClientProgressOffer(profileId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("ClientCompletedOffer/{profileId}")]
        public async Task<IActionResult> ClientCompletedOffer(int profileId)
        {
            try
            {
                var result = await OfferInfoService.GetClientCompletedOffer(profileId);
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

        [HttpGet("GetById/{offerInfoId}")]
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
        #region Operator
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

        [HttpPost("CompletedOfferByOperator")]
        public async Task<IActionResult> CompletedOfferByOperator(int profileId, int offerInfoId)
        {
            try
            {
                var returnRes = "";
                var file = HttpContext.Request.Form.Files[0];
                // var result = await OfferInfoService.OperatorChangeOfferStatusRequest(profileId, offerInfoId, status);
                if (file != null)
                {
                    string folder ="CompletedReceipt";
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    string fileExt = Path.GetExtension(file.FileName);
                    string docName = $"{fileName}-{offerInfoId}-{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}{fileExt}";
                    string regex = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                    Regex reg = new Regex(string.Format("[{0}]", Regex.Escape(regex)));
                    docName = reg.Replace(docName, "-");
                    //string folder = entity.ProfileId.ToString() + "/" + entity.DocumentTypeId;
                    var name = FileHandler.SaveFile(file, folder, docName);
                    string receiptUrl= $"/assets/documents/{folder}/{docName}";

                 returnRes=   await OfferInfoService.CompletedOfferByOperator(offerInfoId, receiptUrl);
                }
                return OkResult(returnRes);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }


        #endregion Operator
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] OfferInfo model)
        {
            var uId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var UserId = (uId != null && uId != string.Empty) ? Guid.Parse(uId) : Guid.Empty;

            if (model.OfferInfoId > 0)
            {
                model.ModifiedBy = UserId;
                model.Modified = DateTime.UtcNow;
            }
            else
            {
                model.CreatedBy = UserId;
                model.Created = DateTime.UtcNow;
                model.Modified = DateTime.UtcNow;
            }

            return await ModelValidation(async () =>
            {
                var result = await OfferInfoService.AddOrUpdate(model);
                return OkResult(result);
            });
        }
              

        [HttpGet("ProgressOfferForChatting")]
        public async Task<IActionResult> GetProgressOfferForChattingAsync()
        {
            try
            {
                var result =await OfferInfoService.GetProgressOfferForChatting();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
