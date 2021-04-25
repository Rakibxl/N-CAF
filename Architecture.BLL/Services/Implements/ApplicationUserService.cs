using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Architecture.Core.Common.Enums;
using Architecture.Core.Repository.Extensions;
using Architecture.BLL.Services.Exceptions;
using Architecture.Core.Common.Constants;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Query;
using Architecture.Core.Common.Helpers;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Context;

namespace Architecture.BLL.Services.Implements
{
    public class ApplicationUserService : Repository<ApplicationUser>, IApplicationUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        protected ApplicationDbContext _db;

        public ApplicationUserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ICurrentUserService currentUserService,
            IDateTime dateTime,
            ApplicationDbContext dbContext
            ) : base(dbContext)
        {
            _db = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public async Task<QueryResult<ApplicationUser>> GetAllAsync(UserQuery queryObj)
        {
            var result = new QueryResult<ApplicationUser>();

            var columnsMap = new Dictionary<string, Expression<Func<ApplicationUser, object>>>()
            {
                ["Name"] = v => v.Name,
                ["userName"] = v => v.UserName,
                ["email"] = v => v.Email
            };

            var query = _userManager.Users.Include(dd => dd.BranchInfo).Include(dd => dd.AppUserType).Include(u => u.UserRoles).ThenInclude(ur => ur.Role).AsQueryable();
            result.Total = await query.CountAsync();

            query = query.Where(x => !x.IsLocked &&
                (string.IsNullOrWhiteSpace(queryObj.FullName) || x.Name.Contains(queryObj.FullName)) &&
                (string.IsNullOrWhiteSpace(queryObj.UserName) || x.UserName.Contains(queryObj.UserName)) &&
                (string.IsNullOrWhiteSpace(queryObj.PhoneNumber) || x.UserName.Contains(queryObj.PhoneNumber)) &&
                (string.IsNullOrWhiteSpace(queryObj.Email) || x.Email.Contains(queryObj.Email)));

            result.TotalFilter = await query.CountAsync();
            query = query.ApplyOrdering(columnsMap, queryObj.SortBy, queryObj.IsSortAscending);
            query = query.ApplyPaging(queryObj.Page, queryObj.PageSize);
            result.Items = (await query.AsNoTracking().ToListAsync());

            return result;
        }

        public async Task<ApplicationUser> GetByIdAsync(Guid id)
        {
            var query = _userManager.Users.Include(dd => dd.OperatorBranches).Include(u => u.UserRoles).ThenInclude(ur => ur.Role).AsQueryable();

            var user = await query.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new NotFoundException(nameof(ApplicationUser), id);
            }

            return user;
        }

        public async Task<string> AddUpdateOperatorBranch(Guid UserId, List<int> OperatorBranchIds)
        {
            try
            {
                var result = "Success";
                var branches = await _db.OperatorBranches.Where(ex => ex.ApplicationUserId == UserId).ToListAsync();
                _dbContext.RemoveRange(branches);

                List<OperatorBranch> operatorBranches = new List<OperatorBranch>();
                foreach (var branch in OperatorBranchIds)
                {
                    operatorBranches.Add(new OperatorBranch
                    {
                        ApplicationUserId = UserId,
                        BranchInfoId = branch
                    });
                }
                await _dbContext.AddRangeAsync(operatorBranches);
                await _dbContext.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region Helper
        public virtual async Task<IList<TResult>> GetAsync<TResult>(Expression<Func<ApplicationUser, TResult>> selector,
                            Expression<Func<ApplicationUser, bool>> predicate = null,
                            Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy = null,
                            Func<IQueryable<ApplicationUser>, IIncludableQueryable<ApplicationUser, object>> include = null,
                            bool disableTracking = true)
        {
            IQueryable<ApplicationUser> query = _userManager.Users.AsQueryable();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = orderBy(query);

            if (disableTracking)
                query = query.AsNoTracking();

            var result = await query.Select(selector).ToListAsync();

            return result;
        }

        public virtual async Task<(IList<TResult> Items, int Total, int TotalFilter)> GetAsync<TResult>(Expression<Func<ApplicationUser, TResult>> selector,
                            Expression<Func<ApplicationUser, bool>> predicate = null,
                            Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy = null,
                            Func<IQueryable<ApplicationUser>, IIncludableQueryable<ApplicationUser, object>> include = null,
                            int pageIndex = 1, int pageSize = 10,
                            bool disableTracking = true)
        {
            IQueryable<ApplicationUser> query = _userManager.Users.AsQueryable();

            int total = await query.CountAsync();
            int totalFilter = total;

            if (include != null)
                query = include(query);

            if (predicate != null)
            {
                query = query.Where(predicate);
                totalFilter = await query.CountAsync();
            }

            if (orderBy != null)
                query = orderBy(query);

            if (disableTracking)
                query = query.AsNoTracking();

            var result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(selector).ToListAsync();

            return (result, total, totalFilter);
        }
        #endregion
    }
}
