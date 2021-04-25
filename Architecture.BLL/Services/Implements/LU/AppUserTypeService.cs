using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Implements.LU;
using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Interfaces.LU;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.LU
{

    public class AppUserTypeService : Repository<AppUserType>, IAppUserTypeService
    {
        private ICurrentUserService currentUserService;
        public AppUserTypeService(ApplicationDbContext dbContext, ICurrentUserService currentUserService) : base(dbContext)
        {
            this.currentUserService = currentUserService;
        }

        public async Task<IEnumerable<AppUserType>> GetAll()
        {
            var appUserType = (int)currentUserService.UserTypeId;

            IEnumerable<AppUserType> result;
            if(appUserType== (int) EnumApplicationUserType.Admin) 
                result = await GetAsync(x => x);
            else
                result = await GetAsync(x => x,x=>x.VisibleForAdmin==false);
            return result;
        }

        public async Task<AppUserType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.AppUserTypeId == id);
            if (checkVal)
            {
                AppUserType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<AppUserType> AddOrUpdate(AppUserType data)
        {
            try
            {
                AppUserType result;
                if (data.AppUserTypeId > 0)
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
            var result = await DeleteAsync(x => x.AppUserTypeId == id);
            return result;
        }
    }
}
