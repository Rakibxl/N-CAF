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

    public class OwnerTypeService : Repository<OwnerType>, IOwnerTypeService
    {
        public OwnerTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<OwnerType>> GetAll()
        {
            IEnumerable<OwnerType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<OwnerType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.OwnerTypeId == id);
            if (checkVal)
            {
                OwnerType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<OwnerType> AddOrUpdate(OwnerType data)
        {
            try
            {
                OwnerType result;
                if (data.OwnerTypeId > 0)
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
            var result = await DeleteAsync(x => x.OwnerTypeId == id);
            return result;
        }
    }

}


