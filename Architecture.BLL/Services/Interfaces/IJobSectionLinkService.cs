using Architecture.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
    public interface IJobSectionLinkService
    {
        //public Task<IEnumerable<JobSectionLink>> GetAll();
        //public Task<JobSectionLink> GetById(int jobSectionLinkId);
        //public Task<JobSectionLink> AddOrUpdate(JobSectionLink jobSectionLink);
         Task<JobSectionLink> AddOrUpdateOrDelete(int jobInfoId, List<JobSectionLink> jobSectionLink);
        //public Task<int> Delete(int jobSectionLinkId);
    }
}
