using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.Core.Entities.LU;

namespace Architecture.BLL.Services.Interfaces.LU
{
    interface IAppUserTypeService
    {
        Task<IEnumerable<AppUserType>> GetAll();
        Task<AppUserType> GetById(int id);
        Task<AppUserType> AddOrUpdate(AppUserType data);
        Task<int> Delete(int id);

    }
}
