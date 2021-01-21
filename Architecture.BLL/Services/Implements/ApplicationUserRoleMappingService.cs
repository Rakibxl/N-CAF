using Architecture.Core.Common.Constants;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Architecture.Core.Repository.Extensions;
using Architecture.BLL.Services.Exceptions;
using Architecture.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Transactions;

namespace Architecture.BLL.Services.Implements
{
    public class ApplicationUserRoleMappingService : IApplicationUserRoleMappingService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationUserRoleMappingService(
            UserManager<ApplicationUser> userManager,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public async Task<List<object>> GetAllAsync(UserRoleQuery queryObj)
        {
            var userRoleList = new List<object>();
            var users = _userManager.Users
                //.Include(br => br.BranchInfo)
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role).ToList();
            foreach (var item in users)
            {
                if (item.UserRoles.Any())
                {
                    foreach (var role in item.UserRoles)
                    {
                        userRoleList.Add(new
                        {
                            UserId = role.UserId,
                            RoleId = role.RoleId,
                            RoleName = role.Role.Name,
                            UserName = role.User.Name,
                            Status = role.Role.Status,
                            BranchId = role.User.BranchInfoId,
                            //BranchName = item.BranchInfo.BranchLocation
                        });
                    }
                }
            }
            return userRoleList;
        }

        public async Task<Guid> AddAsync(ApplicationUser entity,string role)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var isExists = await _userManager.IsInRoleAsync(entity, role);
                    if (isExists)
                    {
                        throw new DuplicationException(nameof(role));
                    }

                    var user = await _userManager.FindByIdAsync(entity.Id.ToString());

                    var roleSaveResult = await _userManager.AddToRoleAsync(user, role);
                    if (!roleSaveResult.Succeeded)
                    {
                        throw new IdentityValidationException(roleSaveResult.Errors);
                    };

                    scope.Complete();

                    return new Guid();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }

        public async Task<Guid> DeleteAsync(ApplicationUser entity, string role)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var isExists = await _userManager.IsInRoleAsync(entity, role);
                    if (isExists)
                    {
                        var user = await _userManager.FindByIdAsync(entity.Id.ToString());

                        var roleSaveResult = await _userManager.RemoveFromRoleAsync(user, role);
                        if (!roleSaveResult.Succeeded)
                        {
                            throw new IdentityValidationException(roleSaveResult.Errors);
                        };
                    }
                    scope.Complete();
                    return new Guid();
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
        }
    }
}
