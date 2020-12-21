using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IDegreeTypeService
    {
        Task<IEnumerable<DegreeType>> GetAll();
        Task<DegreeType> GetById(int id);
        Task<DegreeType> AddOrUpdate(DegreeType data);
        Task<int> Delete(int id);
    }
}
