
using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IISEEClassTypeService
    {
        Task<IEnumerable<ISEEClassType>> GetAll();
        Task<ISEEClassType> GetById(int id);
        Task<ISEEClassType> AddOrUpdate(ISEEClassType data);
        Task<int> Delete(int id);
    }
}


