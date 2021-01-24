using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Context;
using Architecture.BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            var checkVal = await IsExistsAsync(x => x.JobInfoId == jobId);
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

        public async Task<JobSectionLink> AddOrUpdateOrDelete(int jobInfId, List<JobSectionLink> jobSectionLink)
        {
            try
            {
                JobInfo result;
                if (jobInfId > 0)
                {
                    foreach (var link in jobSectionLink)
                    {
                        link.JobInfoId = jobInfId;
                    }

                    var existingsItems = await GetAsync(x => x, x => x.JobInfoId == jobInfId);
                    List<JobSectionLink> deletedItems = new List<JobSectionLink>();
                    foreach (var item in existingsItems)
                    {
                        if(jobSectionLink.Find(x=>x.SectionNameId== item.SectionNameId) == null)
                        {
                            deletedItems.Add(item);
                        }
                    }

                    if(deletedItems.Count>0) await DeleteRangeAsync(deletedItems);
                    if (jobSectionLink.FindAll(x => x.JobSectionLinkId > 0).Count > 0) await UpdateRangeAsync(jobSectionLink.FindAll(x => x.JobSectionLinkId > 0));
                    if (jobSectionLink.FindAll(x => x.JobSectionLinkId ==0).Count > 0) await AddRangeAsync(jobSectionLink.FindAll(x => x.JobSectionLinkId == 0));
                }
                else
                {
                    if (jobSectionLink.FindAll(x => x.JobSectionLinkId == 0).Count > 0) await AddRangeAsync(jobSectionLink.FindAll(x => x.JobSectionLinkId == 0));
                }

                return new JobSectionLink();
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

        public async Task<JobSectionLink> AddOrUpdateOrDelete(int jobInfId, ICollection<JobSectionLink> jobSectionLink)
        {
            try
            {
                JobInfo result;
                List<JobSectionLink> listOfJobSectionLink = jobSectionLink.ToList();
                if (jobInfId > 0)
                {
                    foreach (var link in jobSectionLink)
                    {
                        link.JobInfoId = jobInfId;
                    }

                    var existingsItems = await GetAsync(x => x, x => x.JobInfoId == jobInfId);
                    List<JobSectionLink> deletedItems = new List<JobSectionLink>();
                    foreach (var item in existingsItems)
                    {
                        if (listOfJobSectionLink.Find(x => x.SectionNameId == item.SectionNameId) == null)
                        {
                            deletedItems.Add(item);
                        }
                    }

                    if (deletedItems.Count > 0) await DeleteRangeAsync(deletedItems);
                    if (listOfJobSectionLink.FindAll(x => x.JobSectionLinkId > 0).Count > 0) await UpdateRangeAsync(listOfJobSectionLink.FindAll(x => x.JobSectionLinkId > 0));
                    if (listOfJobSectionLink.FindAll(x => x.JobSectionLinkId == 0).Count > 0)
                    {
                        await AddAsync(new JobSectionLink()
                        {
                            Created= DateTime.Now,
                            CreatedBy=null,
                            JobInfoId=1,
                            JobSectionLinkId=0,
                            Modified=DateTime.Now,
                            ModifiedBy=null,
                            RecordStatus=null,
                            RecordStatusId=null,
                            SectionNameId=1
                        });
                        //await AddRangeAsync(listOfJobSectionLink.FindAll(x => x.JobSectionLinkId == 0));
                    }

                }
                else
                {
                    if (listOfJobSectionLink.FindAll(x => x.JobSectionLinkId == 0).Count > 0) await AddRangeAsync(listOfJobSectionLink.FindAll(x => x.JobSectionLinkId == 0));
                }

                return new JobSectionLink();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
