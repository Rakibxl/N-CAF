
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
   public class EyeColorService : Repository<EyeColor>, IEyeColorService
    {
        public EyeColorService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<EyeColor>> GetAll()
        {
            IEnumerable<EyeColor> result;
            result = await GetAsync(x => x,x=>x.IsActive);
            return result;
        }

        public async Task<EyeColor> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.EyeColorId == id);
            if (checkVal)
            {
                EyeColor result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<EyeColor> AddOrUpdate(EyeColor data)
        {
            try
            {
                EyeColor result;
                if (data.EyeColorId > 0)
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
            var result = await DeleteAsync(x => x.EyeColorId == id);
            return result;
        }
    }

}

