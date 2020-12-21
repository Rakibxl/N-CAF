using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.Core.Entities.LU;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IContractTypeService
    {
        Task<IEnumerable<ContractType>> GetAll();
        Task<ContractType> GetById(int id);
        Task<ContractType> AddOrUpdate(ContractType data);
        Task<int> Delete(int id);
    }
}
