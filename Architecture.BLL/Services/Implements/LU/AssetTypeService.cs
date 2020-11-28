using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.LU;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.LU
{

    public class AssetTypeService : Repository<AssetType>, IAssetTypeService
    {
        public AssetTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<AssetType>> GetAll()
        {
            IEnumerable<AssetType> result;
            result = await GetAsync(x => x);
            return result;
        }

        public async Task<AssetType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.AssetTypeId == id);
            if (checkVal)
            {
                AssetType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<AssetType> AddOrUpdate(AssetType data)
        {
            try
            {
                AssetType result;
                if (data.AssetTypeId > 0)
                {
                    result = await UpdateAsync(data);
                }
                else
                {
                    result = await AddAsync(data);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int id)
        {
            var result = await DeleteAsync(x => x.AssetTypeId == id);
            return result;
        }
    }

}
