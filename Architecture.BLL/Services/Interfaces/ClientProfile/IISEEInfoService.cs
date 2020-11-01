using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IISEEInfoService
    {
        public Task<ProfISEEInfo> AddOrUpdate(ProfISEEInfo iseeInfo);
        public Task<ProfISEEInfo> GetById(int iseeInfoId);
        public Task<int> Delete(int iseeInfoId);
        public Task<IEnumerable<ProfISEEInfo>> GetAll(int profileId);
    }
}
