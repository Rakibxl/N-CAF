using Architecture.BLL.Services.Interfaces.LU;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements.LU
{
  
    public class ProvinceService : Repository<Province>, IProvinceService
    {
        public ProvinceService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Province>> GetAll()
        {
            IEnumerable<Province> result;
            result = await GetAsync(x => x, x => x.IsActive == true);
            return result;
        }

        public async Task<Province> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.ProvinceId == id);
            if (checkVal)
            {
                Province result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<Province> AddOrUpdate(Province addressType)
        {
            try
            {
                Province result;
                if (addressType.ProvinceId > 0)
                {
                    result = await UpdateAsync(addressType);
                }
                else
                {
                    result = await AddAsync(addressType);
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
            var result = await DeleteAsync(x => x.ProvinceId == id);
            return result;
        }
    }
}
