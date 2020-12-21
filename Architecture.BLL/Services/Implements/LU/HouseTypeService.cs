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

    public class HouseTypeService : Repository<HouseType>, IHouseTypeService
    {
        public HouseTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<HouseType>> GetAll()
        {
            IEnumerable<HouseType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<HouseType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.HouseTypeId == id);
            if (checkVal)
            {
                HouseType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<HouseType> AddOrUpdate(HouseType data)
        {
            try
            {
                HouseType result;
                if (data.HouseTypeId > 0)
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
            var result = await DeleteAsync(x => x.HouseTypeId == id);
            return result;
        }
    }

}

