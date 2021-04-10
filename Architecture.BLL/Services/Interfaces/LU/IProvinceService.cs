using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IProvinceService
    {
        Task<IEnumerable<Province>> GetAll();
        Task<Province> GetById(int id);
        Task<Province> AddOrUpdate(Province province);
        Task<int> Delete(int id);
    }
}
