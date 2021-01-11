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

    public class JobSectionLinkService : Repository<JobSectionLink>, IJobSectionLinkService
    {
        public JobSectionLinkService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<JobSectionLink>> GetAll()
        {
            IEnumerable<JobSectionLink> result;
            result = await GetAsync(x => x, null, null, x => x.Include(y => y.SectionName));
            return result;
        }

        public async Task<JobSectionLink> GetById(int jobId)
        {
            var checkVal = await IsExistsAsync(x => x.JobId == jobId);
            if (checkVal)
            {
                JobSectionLink result = await GetByIdAsync(jobId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<JobSectionLink> AddOrUpdate(JobSectionLink jobSectionLink)
        {
            try
            {
                JobSectionLink result;
                if (jobSectionLink.JobSectionLinkId > 0)
                {
                    result = await UpdateAsync(jobSectionLink);
                }
                else
                {
                    result = await AddAsync(jobSectionLink);
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
