using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IWorkerTypeService
    {
        Task<IEnumerable<WorkerType>> GetAll();
        Task<WorkerType> GetById(int id);
        Task<WorkerType> AddOrUpdate(WorkerType data);
        Task<int> Delete(int id);
    }
}
