
using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IInsuranceTypeService
    {
        Task<IEnumerable<InsuranceType>> GetAll();
        Task<InsuranceType> GetById(int id);
        Task<InsuranceType> AddOrUpdate(InsuranceType data);
        Task<int> Delete(int id);

    }
}


