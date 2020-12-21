using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface ILoanStatusTypeService
    {
        Task<IEnumerable<LoanStatusType>> GetAll();
        Task<LoanStatusType> GetById(int id);
        Task<LoanStatusType> AddOrUpdate(LoanStatusType data);
        Task<int> Delete(int id);
    }
}


