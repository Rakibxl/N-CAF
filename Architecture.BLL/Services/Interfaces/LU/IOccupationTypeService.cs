using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IOccupationTypeService
    {
        Task<IEnumerable<OccupationType>> GetAll();
        Task<OccupationType> GetById(int id);
        Task<OccupationType> AddOrUpdate(OccupationType data);
        Task<int> Delete(int id);
    }
}
