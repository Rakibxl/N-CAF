using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IResidenceScopeService
    {
        Task<IEnumerable<ResidenceScope>> GetAll();
        Task<ResidenceScope> GetById(int id);
        Task<ResidenceScope> AddOrUpdate(ResidenceScope data);
        Task<int> Delete(int id);
    }
}
