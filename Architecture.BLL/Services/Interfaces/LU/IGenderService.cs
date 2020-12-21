
using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IGenderService
    {
        Task<IEnumerable<Gender>> GetAll();
        Task<Gender> GetById(int id);
        Task<Gender> AddOrUpdate(Gender data);
        Task<int> Delete(int id);

    }
}

