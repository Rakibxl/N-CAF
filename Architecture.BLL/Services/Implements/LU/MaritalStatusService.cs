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

    public class MaritalStatusService : Repository<MaritalStatus>, IMaritalStatusService
    {
        public MaritalStatusService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<MaritalStatus>> GetAll()
        {
            IEnumerable<MaritalStatus> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<MaritalStatus> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.MaritalStatusId == id);
            if (checkVal)
            {
                MaritalStatus result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<MaritalStatus> AddOrUpdate(MaritalStatus data)
        {
            try
            {
                MaritalStatus result;
                if (data.MaritalStatusId > 0)
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
            var result = await DeleteAsync(x => x.MaritalStatusId == id);
            return result;
        }
    }

}


