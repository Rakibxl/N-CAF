using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface ISectionNameService
    {
        Task<IEnumerable<SectionName>> GetAll();
        Task<SectionName> GetById(int id);
        Task<SectionName> AddOrUpdate(SectionName data);
        Task<int> Delete(int id);
    }
}
