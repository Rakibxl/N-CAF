
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

    public class LoanInterestTypeService : Repository<LoanInterestType>, ILoanInterestTypeService
    {
        public LoanInterestTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<LoanInterestType>> GetAll()
        {
            IEnumerable<LoanInterestType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<LoanInterestType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.LoanInterestTypeId == id);
            if (checkVal)
            {
                LoanInterestType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<LoanInterestType> AddOrUpdate(LoanInterestType data)
        {
            try
            {
                LoanInterestType result;
                if (data.LoanInterestTypeId > 0)
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
            var result = await DeleteAsync(x => x.LoanInterestTypeId == id);
            return result;
        }
    }

}

