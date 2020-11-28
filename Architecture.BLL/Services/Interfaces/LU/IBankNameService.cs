using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.Core.Entities.LU;

namespace Architecture.BLL.Services.Interfaces.LU
{
    interface IBankNameService
    {
        Task<IEnumerable<BankName>> GetAll();
        Task<BankName> GetById(int id);
        Task<BankName> AddOrUpdate(BankName data);
        Task<int> Delete(int id);
    }
}
