using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IIncomeTypeService
    {
        Task<IEnumerable<IncomeType>> GetAll();
        Task<IncomeType> GetById(int id);
        Task<IncomeType> AddOrUpdate(IncomeType data);
        Task<int> Delete(int id);

    }
}

