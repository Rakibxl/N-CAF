
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

    public class HouseCategoryService : Repository<HouseCategory>, IHouseCategoryService
    {
        public HouseCategoryService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<HouseCategory>> GetAll()
        {
            IEnumerable<HouseCategory> result;
            result = await GetAsync(x => x,x=>x.IsActive);
            return result;
        }

        public async Task<HouseCategory> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.HouseCategoryId == id);
            if (checkVal)
            {
                HouseCategory result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<HouseCategory> AddOrUpdate(HouseCategory data)
        {
            try
            {
                HouseCategory result;
                if (data.HouseCategoryId > 0)
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
            var result = await DeleteAsync(x => x.HouseCategoryId == id);
            return result;
        }
    }

}

