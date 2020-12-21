using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface ILoanInterestTypeService
    {
        Task<IEnumerable<LoanInterestType>> GetAll();
        Task<LoanInterestType> GetById(int id);
        Task<LoanInterestType> AddOrUpdate(LoanInterestType data);
        Task<int> Delete(int id);
    }
}

