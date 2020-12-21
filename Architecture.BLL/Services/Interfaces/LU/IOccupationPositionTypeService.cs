using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IOccupationPositionTypeService
    {
        Task<IEnumerable<OccupationPositionType>> GetAll();
        Task<OccupationPositionType> GetById(int id);
        Task<OccupationPositionType> AddOrUpdate(OccupationPositionType data);
        Task<int> Delete(int id);
    }
}
