using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.Core.Entities.LU;

namespace Architecture.BLL.Services.Interfaces.LU
{
    interface IAssetTypeService
    {
        Task<IEnumerable<AssetType>> GetAll();
        Task<AssetType> GetById(int id);
        Task<AssetType> AddOrUpdate(AssetType data);
        Task<int> Delete(int id);
    }
}
