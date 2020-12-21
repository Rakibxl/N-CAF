using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IOccupationPositionService
    {
        Task<IEnumerable<OccupationPosition>> GetAll();
        Task<OccupationPosition> GetById(int id);
        Task<OccupationPosition> AddOrUpdate(OccupationPosition data);
        Task<int> Delete(int id);
    }
}
