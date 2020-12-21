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

    public class InsuranceTypeService : Repository<InsuranceType>, IInsuranceTypeService
    {
        public InsuranceTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<InsuranceType>> GetAll()
        {
            IEnumerable<InsuranceType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<InsuranceType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.InsuranceTypeId == id);
            if (checkVal)
            {
                InsuranceType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<InsuranceType> AddOrUpdate(InsuranceType data)
        {
            try
            {
                InsuranceType result;
                if (data.InsuranceTypeId > 0)
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
            var result = await DeleteAsync(x => x.InsuranceTypeId == id);
            return result;
        }
    }

}


