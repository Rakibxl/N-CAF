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

    public class IncomeTypeService : Repository<IncomeType>, IIncomeTypeService
    {
        public IncomeTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<IncomeType>> GetAll()
        {
            IEnumerable<IncomeType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<IncomeType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.IncomeTypeId == id);
            if (checkVal)
            {
                IncomeType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<IncomeType> AddOrUpdate(IncomeType data)
        {
            try
            {
                IncomeType result;
                if (data.IncomeTypeId > 0)
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
            var result = await DeleteAsync(x => x.IncomeTypeId == id);
            return result;
        }
    }

}


