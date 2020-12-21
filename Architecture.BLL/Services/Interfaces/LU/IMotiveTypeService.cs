using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IMotiveTypeService
    {
        Task<IEnumerable<MotiveType>> GetAll();
        Task<MotiveType> GetById(int id);
        Task<MotiveType> AddOrUpdate(MotiveType data);
        Task<int> Delete(int id);
    }
}
