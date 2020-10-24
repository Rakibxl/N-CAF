using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IWorkerInfoService
    {
        public Task<ProfWorkerInfo> AddOrUpdate(ProfWorkerInfo workerInfo);
        public Task<ProfWorkerInfo> GetById(int workerInfoId);
        public Task<int> Delete(int workerInfoId);
        public Task<IEnumerable<ProfWorkerInfo>> GetAll(int profileId);
    }
}
