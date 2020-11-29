using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IAssetInfoService
    {
        public Task<ProfAssetInfo> AddOrUpdate(ProfAssetInfo assetInfo);
        public Task<ProfAssetInfo> GetById(int profileId, int assetInfoId);
        public Task<int> Delete(int assetInfoId);
        public Task<IEnumerable<ProfAssetInfo>> GetAll(int profileId);
    }
}
