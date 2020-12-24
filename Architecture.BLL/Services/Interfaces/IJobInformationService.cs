using Architecture.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
    public interface IJobInformationService
    {
        public Task<IEnumerable<JobInformation>> GetAll();
        public Task<JobInformation> GetById(int jobId);
        public Task<JobInformation> AddOrUpdate(JobInformation jobInfo);
        public Task<int> Delete(int jobId);
    }
}
