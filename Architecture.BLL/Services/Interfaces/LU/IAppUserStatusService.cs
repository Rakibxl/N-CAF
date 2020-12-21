using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.Core.Entities.LU;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IAppUserStatusService
    {
        Task<IEnumerable<AppUserStatus>> GetAll();
        Task<AppUserStatus> GetById(int id);
        Task<AppUserStatus> AddOrUpdate(AppUserStatus data);
        Task<int> Delete(int id);
    }
}
