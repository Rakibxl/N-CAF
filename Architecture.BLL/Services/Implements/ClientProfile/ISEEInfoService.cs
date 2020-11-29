using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class ISEEInfoService : Repository<ProfISEEInfo>, IISEEInfoService
    {
        public ISEEInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfISEEInfo> AddOrUpdate(ProfISEEInfo iseeInfo)
        {
            try
            {
                ProfISEEInfo result;
                if (iseeInfo.ISEEInfoId > 0)
                {
                    result = await UpdateAsync(iseeInfo);
                }
                else
                {
                    result = await AddAsync(iseeInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int iseeInfoId)
        {
            var result = await DeleteAsync(x=>x.ISEEInfoId == iseeInfoId);
            return result;
        }

        public async Task<ProfISEEInfo> GetById(int profileId, int iseeInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.ISEEInfoId == iseeInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfISEEInfo result = await GetByIdAsync(iseeInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfISEEInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfISEEInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
