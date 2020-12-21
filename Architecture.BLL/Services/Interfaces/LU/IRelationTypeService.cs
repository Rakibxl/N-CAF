using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IRelationTypeService
    {
        Task<IEnumerable<RelationType>> GetAll();
        Task<RelationType> GetById(int id);
        Task<RelationType> AddOrUpdate(RelationType data);
        Task<int> Delete(int id);
    }
}
