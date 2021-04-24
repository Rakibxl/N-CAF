using Architecture.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
    public interface IJobInformationService
    {
        public Task<IEnumerable<JobInfo>> GetAll();
        public Task<JobInfo> GetById(int jobId);
        public Task<JobInfo> AddOrUpdate(JobInfo jobInfo);
        public Task<string> Delete(int jobId);
    }
}
