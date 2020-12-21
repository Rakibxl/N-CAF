using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface INationalityService
    {
        Task<IEnumerable<Nationality>> GetAll();
        Task<Nationality> GetById(int id);
        Task<Nationality> AddOrUpdate(Nationality data);
        Task<int> Delete(int id);
    }
}
