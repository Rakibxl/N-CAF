using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IEducationInfoService
    {
        public Task<ProfEducationInfo> AddOrUpdate(ProfEducationInfo educationInfo);
        public Task<ProfEducationInfo> GetById(int profileId, int educationInfoId);
        public Task<int> Delete(int educationInfoId);
        public Task<IEnumerable<ProfEducationInfo>> GetAll(int profileId);
    }
}
