using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IMovementInfoService
    {
        public Task<ProfMovementInfo> AddOrUpdate(ProfMovementInfo movementInfo);
        public Task<ProfMovementInfo> GetById(int profileId, int movementInfoId);
        public Task<int> Delete(int movementInfoId);
        public Task<IEnumerable<ProfMovementInfo>> GetAll(int profileId);
    }
}
