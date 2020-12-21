using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface INationalIdTypeService
    {
        Task<IEnumerable<NationalIdType>> GetAll();
        Task<NationalIdType> GetById(int id);
        Task<NationalIdType> AddOrUpdate(NationalIdType data);
        Task<int> Delete(int id);
    }
}
