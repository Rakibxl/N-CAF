using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities.Accounts;
using Architecture.Web.Controllers.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web.Controllers.ClientProfile
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/Recharge")]
    public class RechargeController : BaseController
    {
        private readonly IRechargeService _rechargeService;

        public RechargeController(IRechargeService rechargeService)
        {
            _rechargeService = rechargeService;
        }

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdateAsync([FromBody] TransactionRequest model)
        {
            return await ModelValidation(async () =>
            {
                var appUserTypeId = GetClaimValue("AppUserTypeId");

                var result = await _rechargeService.AddOrUpdateAsync(model);
                return OkResult(result);
            });
        }

        [HttpGet("Pending")]
        public async Task<IActionResult> GetAllPendingApprovalsAsync()
        {
            return await ModelValidation(async () => OkResult(await _rechargeService.GetAllAsync()));
        }

        [HttpGet("Approve/{transactionRequestId}")]
        public async Task<IActionResult> ApprovalPendingRechargeAsync(int transactionRequestId)
        {
            return await ModelValidation(async () => OkResult(await _rechargeService.ApprovePendingRechargeAsync(transactionRequestId)));
        }

        [HttpGet("Reject/{transactionRequestId}")]
        public async Task<IActionResult> RejectPendingRechargeAsync(int transactionRequestId)
        {
            return await ModelValidation(async () => OkResult(await _rechargeService.RejectPendingRechargeAsync(transactionRequestId)));
        }
    }
}
