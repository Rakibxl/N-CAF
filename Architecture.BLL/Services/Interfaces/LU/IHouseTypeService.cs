using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IHouseTypeService
    {
        Task<IEnumerable<HouseType>> GetAll();
        Task<HouseType> GetById(int id);
        Task<HouseType> AddOrUpdate(HouseType data);
        Task<int> Delete(int id);

    }
}

