using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Architecture.BLL.Services.Interfaces;
using Architecture.Web.Controllers.Common;
using Architecture.Web.Core;
using Architecture.Web.Models;
using Architecture.Web.Models.IdentityModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Architecture.Web.Controllers.Users
{
    [Authorize]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/users")]
    public class UsersController : BaseController
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(
            IApplicationUserService applicationUserService,
            IOptionsSnapshot<AppSettings> appOptions,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            this._applicationUserService = applicationUserService;
            this._appSettings = appOptions.Value;
            this._mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        //[Authorize(Permissions.Users.ListView)]
        public async Task<IActionResult> Get([FromQuery] UserQuery query)
        {
            try
            {
                var result = await _applicationUserService.GetAllAsync(query);
                var queryResult = _mapper.Map<QueryResult<ApplicationUser>, QueryResult<UserModel>>(result);
                var data = queryResult.Items.ToList();
                
                var AppUserTypeId = GetClaimValue("AppUserTypeId");
                if (AppUserTypeId == "1")
                {

                }
                else if (AppUserTypeId == "2")
                {
                    var BranchInfoId = GetClaimValue("BranchInfoId");
                    if (BranchInfoId != null && !string.IsNullOrEmpty(BranchInfoId))
                    {
                        data = data.Where(ex => ex.BranchInfoId != null && ex.BranchInfoId.Value == int.Parse(BranchInfoId)).ToList();
                    }
                    else
                    {
                        data = new List<UserModel>();
                    }
                }
                else
                {
                    data = new List<UserModel>();
                }
                return OkResult(data);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("{id}")]
        //[Authorize(Permissions.Users.DetailsView)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var user = await _applicationUserService.GetByIdAsync(id);
                var result = _mapper.Map<ApplicationUser, UserModel>(user);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpPost("CreateOrUpdate")]
        //[Authorize(Permissions.Users.Create)]
        public async Task<IActionResult> CreateOrUpdate([FromBody] SaveUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationResult(ModelState);
            }

            try
            {
                //IdentityResult result = new IdentityResult();
                ApplicationUser user;
                var uId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var UserId = (uId != null && uId != string.Empty) ? Guid.Parse(uId) : Guid.Empty;

                if (model.Id != Guid.Empty)
                {
                    user = await _userManager.FindByIdAsync(model.Id.ToString());
                    if (user != null)
                    {
                        user.Name = model.Name;
                        user.SurName = model.SurName;
                        user.UserName = model.PhoneNumber;
                        user.Email = model.Email;
                        user.PhoneNumber = model.PhoneNumber;
                        user.AppUserTypeId = model.AppUserTypeId;
                        user.BranchInfoId = model.BranchInfoId;
                        user.OperatorKeywordIds = model.OperatorKeywordIds;
                        user.ModifiedBy = UserId;
                        user.Modified = DateTime.Now;

                        await _userManager.UpdateAsync(user);

                        await _applicationUserService.AddUpdateOperatorBranch(model.Id, model.OperatorBranches);
                    }
                }
                else
                {
                    var userExists = await _userManager.FindByEmailAsync(model.Email);
                    if (userExists != null)
                    {
                        userExists = _userManager.Users.Where(ex => ex.PhoneNumber == model.PhoneNumber).FirstOrDefault();
                        if (userExists != null)
                        {
                            ModelState.AddModelError("", "User email already exists! & User phone no already exists!");
                        }
                        else
                        {
                            ModelState.AddModelError("", "User email already exists!");
                        }
                        return ValidationResult(ModelState);
                    }

                    userExists = _userManager.Users.Where(ex => ex.PhoneNumber == model.PhoneNumber).FirstOrDefault();
                    if (userExists != null)
                    {
                        ModelState.AddModelError("", "User phone no already exists!");
                        return ValidationResult(ModelState);
                    }

                    user = new ApplicationUser()
                    {
                        Name = model.Name,
                        SurName = model.SurName,
                        UserName = model.PhoneNumber,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        AppUserTypeId = model.AppUserTypeId,
                        BranchInfoId = model.BranchInfoId,
                        GenderId = model.GenderId,
                        OperatorKeywordIds = model.OperatorKeywordIds,
                        CreatedBy = UserId,
                        Created = DateTime.Now
                    };
                    
                    await _userManager.CreateAsync(user, model.Password);
                    await _applicationUserService.AddUpdateOperatorBranch(model.Id, model.OperatorBranches);
                };

                //var result = await _applicationUserService.AddOrUpdate(user);
                return OkResult(user);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        //[HttpGet("except-app-users")]
        ////[Authorize(Permissions.Users.ListView)]
        //public async Task<IActionResult> GetExceptAppUsers([FromQuery] UserQuery query)
        //{
        //    try
        //    {
        //        var result = await _applicationUserService.GetAllExceptAppUsersAsync(query);
        //        var queryResult = _mapper.Map<QueryResult<ApplicationUser>, QueryResult<UserModel>>(result);
        //        return OkResult(queryResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}

        //[HttpGet("app-users")]
        ////[Authorize(Permissions.Users.ListView)]
        //public async Task<IActionResult> GetAppUsers([FromQuery] UserQuery query)
        //{
        //    try
        //    {
        //        var result = await _applicationUserService.GetAllAppUsersAsync(query);
        //        var queryResult = _mapper.Map<QueryResult<ApplicationUser>, QueryResult<UserModel>>(result);
        //        return OkResult(queryResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}

        //[HttpPost]
        ////[Authorize(Permissions.Users.Create)]
        //public async Task<IActionResult> Create([FromBody] SaveUserModel model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return ValidationResult(ModelState);

        //        var user = _mapper.Map<SaveUserModel, ApplicationUser>(model);
        //        var result = await _applicationUserService.AddAsync(user, model.UserRoleId, _appSettings.UserDefaultPassword);
        //        return OkResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}

        //[HttpPut("{id}")]
        ////[Authorize(Permissions.Users.Edit)]
        //public async Task<IActionResult> Update(Guid id, [FromBody] SaveUserModel model)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return ValidationResult(ModelState);

        //        var user = _mapper.Map<SaveUserModel, ApplicationUser>(model);
        //        await _applicationUserService.UpdateAsync(user, model.UserRoleId);
        //        return OkResult(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}

        //[HttpDelete("{id}")]
        ////[Authorize(Permissions.Users.Delete)]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    try
        //    {
        //        await _applicationUserService.DeleteAsync(id);
        //        return OkResult(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}

        //[HttpPost("activeInactive/{id}")]
        //public async Task<IActionResult> ActiveInactive(Guid id)
        //{
        //    try
        //    {
        //        await _applicationUserService.ActiveInactiveAsync(id);
        //        return OkResult(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}
    }
}
