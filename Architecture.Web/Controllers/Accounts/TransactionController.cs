using Architecture.BLL.Services.Implements.Accounts;
using Architecture.BLL.Services.Interfaces.Accounts;
using Architecture.Core.Entities.Accounts;
using Architecture.Web.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Web.Controllers.Accounts
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/Transaction")]
    public class TransactionController : BaseController
    {
        private readonly IAccountInfoService _accountInfoService;
        private readonly ITransactionService _transactionService;

        public TransactionController(IAccountInfoService accountInfoService, ITransactionService transactionService)
        {
            _accountInfoService = accountInfoService;
            _transactionService = transactionService;
        }


        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] Transaction model)
        {
            return await ModelValidation(async () =>
            {
                var result = await _transactionService.AddOrUpdate(model);
                return OkResult(result);
            });
        }

        [HttpGet("GetAllTransactionInfo")]
        public async Task<IActionResult> GetAllAccountInfo()
        {
            try
            {
                var result = await _transactionService.GetAll();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        } 
        
        [HttpGet("ApprovalRejectOperatorAmount/{transactionId}/{status}")]
        public async Task<IActionResult> ApprovalRejectOperatorAmount(int transactionId, string status )
        {
            try
            {
               
                var result = await _transactionService.ApprovalRejectOperatorAmount(transactionId, status);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
        
        [HttpGet("GetPendingApprovalTransaction")]
        public async Task<IActionResult> GetPendingApprovalTransaction()
        {
            try
            {
                var result = await _transactionService.GetPendingApproval();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}
