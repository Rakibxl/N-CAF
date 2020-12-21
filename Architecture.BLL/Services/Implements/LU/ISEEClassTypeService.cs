
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

    public class ISEEClassTypeService : Repository<ISEEClassType>, IISEEClassTypeService
    {
        public ISEEClassTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<ISEEClassType>> GetAll()
        {
            IEnumerable<ISEEClassType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<ISEEClassType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.ISEEClassTypeId == id);
            if (checkVal)
            {
                ISEEClassType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<ISEEClassType> AddOrUpdate(ISEEClassType data)
        {
            try
            {
                ISEEClassType result;
                if (data.ISEEClassTypeId > 0)
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
            var result = await DeleteAsync(x => x.ISEEClassTypeId == id);
            return result;
        }
    }

}



