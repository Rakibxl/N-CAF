using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IDelegationInfoService
    {
        public Task<ProfDelegationInfo> AddOrUpdate(ProfDelegationInfo delegationInfo);
        public Task<ProfDelegationInfo> GetById(int profileId, int delegationInfoId);
        public Task<int> Delete(int delegationInfoId);
        public Task<IEnumerable<ProfDelegationInfo>> GetAll(int profileId);
    }
}
