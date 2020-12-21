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

    public class BankNameService : Repository<BankName>, IBankNameService
    {
        public BankNameService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<BankName>> GetAll()
        {
            IEnumerable<BankName> result;
            result = await GetAsync(x => x,x=>x.IsActive);
            return result;
        }

        public async Task<BankName> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.BankNameId == id);
            if (checkVal)
            {
                BankName result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<BankName> AddOrUpdate(BankName data)
        {
            try
            {
                BankName result;
                if (data.BankNameId > 0)
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
            var result = await DeleteAsync(x => x.BankNameId == id);
            return result;
        }
    }

}
