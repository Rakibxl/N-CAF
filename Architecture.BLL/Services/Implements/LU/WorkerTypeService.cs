using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.LU;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.LU
{

    public class WorkerTypeService : Repository<WorkerType>, IWorkerTypeService
    {
        public WorkerTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<WorkerType>> GetAll()
        {
            IEnumerable<WorkerType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<WorkerType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.WorkerTypeId == id);
            if (checkVal)
            {
                WorkerType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<WorkerType> AddOrUpdate(WorkerType data)
        {
            try
            {
                WorkerType result;
                if (data.WorkerTypeId > 0)
                {
                    result = await UpdateAsync(data);
                }
                else
                {
                    result = await AddAsync(data);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int id)
        {
            var result = await DeleteAsync(x => x.WorkerTypeId == id);
            return result;
        }
    }

}


