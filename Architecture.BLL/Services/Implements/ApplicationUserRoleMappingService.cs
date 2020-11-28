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
        private readonly RoleManager<ApplicationUserRole> _roleManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public ApplicationUserRoleMappingService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationUserRole> roleManager,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public async Task<QueryResult<ApplicationUserRole>> GetAllAsync(UserRoleQuery queryObj)
        {
            var result = new QueryResult<ApplicationUserRole>();

            var columnsMap = new Dictionary<string, Expression<Func<ApplicationUserRole, object>>>()
            {
                ["userId"] = v => v.UserId,
                ["roleId"] = v => v.RoleId,
            };

            var query = _roleManager.Roles.AsQueryable();
            result.Total = await query.CountAsync();

            //query = query.Where(x => !x.IsDeleted &&
                //x.Status != EnumApplicationRoleStatus.Inactive &&
                //(string.IsNullOrWhiteSpace(queryObj.Name) || x.Name.Contains(queryObj.Name)));

            result.TotalFilter = await query.CountAsync();
            query = query.ApplyOrdering(columnsMap, queryObj.SortBy, queryObj.IsSortAscending);
            query = query.ApplyPaging(queryObj.Page, queryObj.PageSize);
            result.Items = (await query.AsNoTracking().ToListAsync());

            return result;
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
    }
}
