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

    public class JobDeliveryTypeService : Repository<JobDeliveryType>, IJobDeliveryTypeService
    {
        public JobDeliveryTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<JobDeliveryType>> GetAll()
        {
            IEnumerable<JobDeliveryType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<JobDeliveryType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.JobDeliveryTypeId == id);
            if (checkVal)
            {
                JobDeliveryType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<JobDeliveryType> AddOrUpdate(JobDeliveryType data)
        {
            try
            {
                JobDeliveryType result;
                if (data.JobDeliveryTypeId > 0)
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
            var result = await DeleteAsync(x => x.JobDeliveryTypeId == id);
            return result;
        }
    }

}




