using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities;
using Architecture.Web.Controllers.Common;
using Architecture.Web.Core;
using Architecture.Web.Models.ClientProfile;
using Architecture.Web.Models.IdentityModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Architecture.Web.Controllers.Users
{
    [Authorize]
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/Branch")]
    public class BranchController : BaseController
    {
        private readonly IBranchService _branchService;
        //private readonly UserManager<ApplicationUser> _userManager;

        public BranchController(IBranchService branchService
            //, UserManager<ApplicationUser> userManager
            )
        {
            _branchService = branchService;
            //_userManager = userManager;
        }

        [HttpGet("GetBranches")]
        [Authorize(Permissions.Branches.ListView)]
        public async Task<IActionResult> GetBranches()
        {
            try
            {
                var result = await _branchService.GetAll();

                var AppUserTypeId = GetClaimValue("AppUserTypeId");
                if (AppUserTypeId == "1")
                {

                }
                else if (AppUserTypeId == "2")
                {
                    var BranchInfoId = GetClaimValue("BranchInfoId");
                    if (BranchInfoId != null && !string.IsNullOrEmpty(BranchInfoId))
                    {
                        result = result.Where(ex => ex.BranchInfoId == int.Parse(BranchInfoId));
                    }
                    else
                    {
                        result = new List<BranchInfo>();
                    }
                }
                else
                {
                    result = new List<BranchInfo>();
                }
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetBranchInfo")]
        public async Task<IActionResult> GetBranchInfo(int branchInfoId)
        {
            try
            {
                var result = await _branchService.GetById(branchInfoId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] BranchInfo model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationResult(ModelState);
            }

            try
            {
                var uId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var UserId = (uId != null && uId != string.Empty) ? Guid.Parse(uId) : Guid.Empty;

                if (model.BranchInfoId > 0)
                {
                    model.ModifiedBy = UserId;
                }
                else
                {
                    model.CreatedBy = UserId;
                }
                var result = await _branchService.AddOrUpdate(model);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }
    }
}