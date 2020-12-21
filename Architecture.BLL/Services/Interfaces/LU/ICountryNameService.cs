using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.Core.Entities.LU;

namespace Architecture.BLL.Services.Interfaces.LU
{
   public interface ICountryNameService
    {
        Task<IEnumerable<CountryName>> GetAll();
        Task<CountryName> GetById(int id);
        Task<CountryName> AddOrUpdate(CountryName data);
        Task<int> Delete(int id);
    }
}
