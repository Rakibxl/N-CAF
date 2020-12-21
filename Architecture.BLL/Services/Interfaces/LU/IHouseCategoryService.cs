
using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IHouseCategoryService
    {
        Task<IEnumerable<HouseCategory>> GetAll();
        Task<HouseCategory> GetById(int id);
        Task<HouseCategory> AddOrUpdate(HouseCategory data);
        Task<int> Delete(int id);

    }
}

