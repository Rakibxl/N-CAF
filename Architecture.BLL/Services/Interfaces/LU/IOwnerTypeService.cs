using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IOwnerTypeService
    {
        Task<IEnumerable<OwnerType>> GetAll();
        Task<OwnerType> GetById(int id);
        Task<OwnerType> AddOrUpdate(OwnerType data);
        Task<int> Delete(int id);
    }
}
