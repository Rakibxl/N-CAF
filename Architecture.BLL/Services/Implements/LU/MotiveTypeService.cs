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

    public class MotiveTypeService : Repository<MotiveType>, IMotiveTypeService
    {
        public MotiveTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<MotiveType>> GetAll()
        {
            IEnumerable<MotiveType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<MotiveType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.MotiveTypeId == id);
            if (checkVal)
            {
                MotiveType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<MotiveType> AddOrUpdate(MotiveType data)
        {
            try
            {
                MotiveType result;
                if (data.MotiveTypeId > 0)
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
            var result = await DeleteAsync(x => x.MotiveTypeId == id);
            return result;
        }
    }

}


