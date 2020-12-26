using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Context;
using Architecture.BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Architecture.BLL.Services.Implements
{

    public class JobInformationService : Repository<JobInformation>, IJobInformationService
    {
        public JobInformationService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<JobInformation>> GetAll()
        {
            IEnumerable<JobInformation> result;
            result = await GetAsync(x => x, null, null, x => x.Include(y => y.JobDeliveryType)
                                                              .Include(y => y.ISEEClassType)
                                                              .Include(y => y.OccupationType)
                                                              .Include(y => y.SectionName));
            return result;
        }

        public async Task<JobInformation> GetById(int jobId)
        {
            var checkVal = await IsExistsAsync(x => x.JobId == jobId);
            if (checkVal)
            {
                JobInformation result = await GetByIdAsync(jobId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<JobInformation> AddOrUpdate(JobInformation  jobInfo)
        {
            try
            {
                JobInformation result;
                if (jobInfo.JobId > 0)
                {
                    result = await UpdateAsync(jobInfo);
                }
                else
                {
                    result = await AddAsync(jobInfo);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int jobId)
        {
            var result = await DeleteAsync(x => x.JobId == jobId);
            return result;
        }
    }
}
