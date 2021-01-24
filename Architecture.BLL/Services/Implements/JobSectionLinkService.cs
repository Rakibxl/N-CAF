using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements
{
    public class JobSectionLinkService : Repository<JobSectionLink>, IJobSectionLinkService
    {
        public JobSectionLinkService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<JobSectionLink> AddOrUpdateOrDelete(int jobInfoId, List<JobSectionLink> jobSectionLink)
        {
            try
            {

                
                //var test=  await AddAsync(data);
                //JobInfo result;
                if (jobInfoId > 0)
                {
                    foreach (var link in jobSectionLink)
                    {
                        link.JobInfoId = jobInfoId;
                    }

                    var existingsItems = await GetAsync(x => x, x => x.JobInfoId == jobInfoId,null,null);
                    List<JobSectionLink> deletedItems = new List<JobSectionLink>();
                    foreach (var item in existingsItems.ToList())
                    {
                        if (jobSectionLink.Find(x => x.SectionNameId == item.SectionNameId) == null)
                        {
                            deletedItems.Add(item);
                        }
                    }

                    // to delete 
                    if (deletedItems.Count > 0)
                    {
                        var deletedRes = await DeleteRangeAsync(deletedItems);
                    }

                    // to update the information
                    if (jobSectionLink.FindAll(x => x.JobSectionLinkId > 0).Count > 0)
                    {
                        var dataSet = jobSectionLink.FindAll(x => x.JobSectionLinkId > 0);
                        var result = await UpdateRangeAsync(dataSet);
                    }

                    // to add new information
                    if (jobSectionLink.FindAll(x => x.JobSectionLinkId == 0).Count > 0)
                    {
                        var addedDataSet = jobSectionLink.FindAll(x => x.JobSectionLinkId == 0).ToList();
                        var res = await AddRangeAsync(addedDataSet);
                    }

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
    }
}
