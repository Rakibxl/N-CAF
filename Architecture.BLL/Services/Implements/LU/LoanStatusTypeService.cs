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

    public class LoanStatusTypeService : Repository<LoanStatusType>, ILoanStatusTypeService
    {
        public LoanStatusTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<LoanStatusType>> GetAll()
        {
            IEnumerable<LoanStatusType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<LoanStatusType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.LoanStatusTypeId == id);
            if (checkVal)
            {
                LoanStatusType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<LoanStatusType> AddOrUpdate(LoanStatusType data)
        {
            try
            {
                LoanStatusType result;
                if (data.LoanStatusTypeId > 0)
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
            var result = await DeleteAsync(x => x.LoanStatusTypeId == id);
            return result;
        }
    }

}


