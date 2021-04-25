using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Context;
using Architecture.BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Architecture.Core.Common.Enums;

namespace Architecture.BLL.Services.Implements
{

    public class JobInformationService : Repository<JobInfo>, IJobInformationService
    {
        private readonly ICurrentUserService currentUserService;
        public JobInformationService(ApplicationDbContext dbContext, ICurrentUserService currentUserService) : base(dbContext)
        {
            this.currentUserService = currentUserService;
        }

        public async Task<IEnumerable<JobInfo>> GetAll()
        {
            IEnumerable<JobInfo> result;
            result = await GetAsync(x => x, x=>x.RecordStatusId== (int)EnumRecordStatus.Active, null, x => x.Include(y => y.JobDeliveryType)
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
                    jobInfo.CreatedBy = currentUserService.UserId;
                    jobInfo.Created = DateTime.Now;
                    result = await UpdateAsync(jobInfo);
                }
                else
                {
                    jobInfo.ModifiedBy = currentUserService.UserId;
                    jobInfo.Modified = DateTime.Now;
                    jobInfo.RecordStatusId = (int)EnumRecordStatus.Active;
                    result = await AddAsync(jobInfo);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Delete(int jobId)
        {
            JobInfo result = await GetFirstOrDefaultAsync(x => x, x => x.JobInfoId == jobId);
            if (result==null) {
                return "Job infomration is not available. Please contact with admin.";
            }
            result.Modified = DateTime.Now;
            result.ModifiedBy = currentUserService.UserId;
            result.RecordStatusId = (int)EnumRecordStatus.Deleted;
            await UpdateAsync(result);
            return "Information deleted successfully.";
        }
    }
}
