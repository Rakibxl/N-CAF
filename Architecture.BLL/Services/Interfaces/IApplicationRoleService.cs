using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
    public interface IApplicationRoleService
    {
        Task<QueryResult<ApplicationRole>> GetAllAsync(UserRoleQuery queryObj);
        Task<(ApplicationRole ApplicationRole, IList<string> Permissions)> GetByIdAsync(Guid id);
        Task<(ApplicationRole ApplicationRole, IList<string> Permissions)> GetByNameAsync(string name);
        Task<Guid> AddAsync(ApplicationRole command, IList<string> permissions);
        Task<Guid> UpdateAsync(ApplicationRole command, IList<string> permissions);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> ActiveInactiveAsync(Guid id);
        Task<IList<KeyValuePairObject>> GetAllForSelectAsync();
        Task<bool> IsExistsNameAsync(string name, Guid id);
    }
}
