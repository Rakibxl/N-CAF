using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements.LU
{
    public class OperatorKeywordService : Repository<OperatorKeyword>, IOperatorKeywordService
    {
        public OperatorKeywordService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<OperatorKeyword>> GetAll()
        {
            IEnumerable<OperatorKeyword> result;
            result = await GetAsync(x => x, x => x.IsActive == true);
            return result;
        }

        public async Task<OperatorKeyword> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.OperatorKeywordId == id);
            if (checkVal)
            {
                OperatorKeyword result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<OperatorKeyword> AddOrUpdate(OperatorKeyword operatorKeyword)
        {
            try
            {
                OperatorKeyword result;
                if (operatorKeyword.OperatorKeywordId > 0)
                {
                    result = await UpdateAsync(operatorKeyword);
                }
                else
                {
                    result = await AddAsync(operatorKeyword);
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
            var result = await DeleteAsync(x => x.OperatorKeywordId == id);
            return result;
        }
    }
}
