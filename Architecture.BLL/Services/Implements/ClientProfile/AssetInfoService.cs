using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class AssetInfoService : Repository<ProfAssetInfo>, IAssetInfoService
    {
        public AssetInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfAssetInfo> AddOrUpdate(ProfAssetInfo assetInfo)
        {
            try
            {
                ProfAssetInfo result;
                if (assetInfo.AssetInfoId > 0)
                {
                    result = await UpdateAsync(assetInfo);
                }
                else
                {
                    result = await AddAsync(assetInfo);
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
            var result = await DeleteAsync(x=>x.AssetInfoId == assetInfoId);
            return result;
        }

        public async Task<ProfAssetInfo> GetById(int profileId, int assetInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.AssetInfoId == assetInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfAssetInfo result = await GetByIdAsync(assetInfoId);
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
              result=await GetAsync(x => x,x => x.ProfileId== profileId,  null, x => x.Include(y => y.AssetType)
                                                                                     .Include(y => y.OwnerType));
            return result;

        }
    }
}
