using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IMaritalStatusService
    {
        Task<IEnumerable<MaritalStatus>> GetAll();
        Task<MaritalStatus> GetById(int id);
        Task<MaritalStatus> AddOrUpdate(MaritalStatus data);
        Task<int> Delete(int id);
    }
}
