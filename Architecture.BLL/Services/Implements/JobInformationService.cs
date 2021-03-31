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

    public class JobInformationService : Repository<JobInfo>, IJobInformationService
    {       
        public JobInformationService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<JobInfo>> GetAll()
        {
            IEnumerable<JobInfo> result;
            result = await GetAsync(x => x, null, null, x => x.Include(y => y.JobDeliveryType)
                                                              .Include(y => y.ISEEClassType)
                                                              .Include(y => y.OccupationType)
                                                              .Include(y => y.JobSectionLink).ThenInclude(x => x.SectionName));
            return result;
        }

        public async Task<JobInfo> GetById(int jobId)
        {
            var checkVal = await IsExistsAsync(x => x.JobInfoId == jobId);
            if (checkVal)
            {
                JobInfo result = await GetFirstOrDefaultAsync(x=>x, x=>x.JobInfoId== jobId, x=>x.Include(y=>y.JobSectionLink).ThenInclude(x=>x.SectionName));
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<JobInfo> AddOrUpdate(JobInfo  jobInfo)
        {
            try
            {
                JobInfo result;
                if (jobInfo.JobInfoId > 0)
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
            var result = await DeleteAsync(x => x.JobInfoId == jobId);
            return result;
        }
    }
}
