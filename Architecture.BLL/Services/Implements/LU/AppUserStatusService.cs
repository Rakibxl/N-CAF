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
   
    public class AppUserStatusService : Repository<AppUserStatus>, IAppUserStatusService
    {
        public AppUserStatusService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<AppUserStatus>> GetAll()
        {
            IEnumerable<AppUserStatus> result;
            result = await GetAsync(x => x);
            return result;
        }

        public async Task<AppUserStatus> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.AppUserStatusId == id);
            if (checkVal)
            {
                AppUserStatus result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<AppUserStatus> AddOrUpdate(AppUserStatus data)
        {
            try
            {
                AppUserStatus result;
                if (data.AppUserStatusId > 0)
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
            var result = await DeleteAsync(x => x.AppUserStatusId == id);
            return result;
        }
    }

}
