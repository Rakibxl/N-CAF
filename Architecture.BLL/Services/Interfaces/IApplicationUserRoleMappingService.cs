using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
    public interface IApplicationUserRoleMappingService
    {
        Task<QueryResult<ApplicationUserRole>> GetAllAsync(UserRoleQuery queryObj);
        Task<Guid> AddAsync(ApplicationUser entity, string role);
    }
}
