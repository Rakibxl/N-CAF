using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IJobTypeService
    {
        Task<IEnumerable<JobType>> GetAll();
        Task<JobType> GetById(int id);
        Task<JobType> AddOrUpdate(JobType data);
        Task<int> Delete(int id);
    }
}

