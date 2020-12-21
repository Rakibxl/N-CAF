
using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IEyeColorService
    {
        Task<IEnumerable<EyeColor>> GetAll();
        Task<EyeColor> GetById(int id);
        Task<EyeColor> AddOrUpdate(EyeColor data);
        Task<int> Delete(int id);

    }
}

