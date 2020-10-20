using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class AssetInfoService : IAssetInfoService
    {
        public IRepository<ProfAssetInfo> assetInfoRepo;
        public async Task<ProfAssetInfo> AddOrUpdate(ProfAssetInfo assetInfo)
        {
            try
            {
                ProfAssetInfo result;
                if (assetInfo.AssetInfoId > 0)
                {
                    result = await assetInfoRepo.UpdateAsync(assetInfo);
                }
                else
                {
                    result = await assetInfoRepo.AddAsync(assetInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int assetInfoId)
        {
            var result = await assetInfoRepo.DeleteAsync(x=>x.AssetInfoId == assetInfoId);
            return result;
        }

        public async Task<ProfAssetInfo> GetById(int assetInfoId)
        {
            var checkVal =await assetInfoRepo.IsExistsAsync(x=>x.AssetInfoId == assetInfoId);
            if (checkVal)
            {
                ProfAssetInfo result = await assetInfoRepo.GetByIdAsync(assetInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfAssetInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfAssetInfo> result;
              result=await assetInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
