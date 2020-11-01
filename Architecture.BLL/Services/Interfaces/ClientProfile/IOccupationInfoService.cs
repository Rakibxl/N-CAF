using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IOccupationInfoService
    {
        public Task<ProfOccupationInfo> AddOrUpdate(ProfOccupationInfo occupationInfo);
        public Task<ProfOccupationInfo> GetById(int occupationInfoId);
        public Task<int> Delete(int occupationInfoId);
        public Task<IEnumerable<ProfOccupationInfo>> GetAll(int profileId);
    }
}
