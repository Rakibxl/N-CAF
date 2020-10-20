using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IAssetInfoService
    {
        public Task<ProfAssetInfo> AddOrUpdate(ProfAssetInfo familyInfo);
        public Task<ProfAssetInfo> GetById(int familyInfoId);
        public Task<int> Delete(int familyInfoId);
        public Task<IEnumerable<ProfAssetInfo>> GetAll(int profileId);
    }
}
