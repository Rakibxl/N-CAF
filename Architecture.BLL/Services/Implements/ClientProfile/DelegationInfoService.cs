using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class DelegationInfoService : Repository<ProfDelegationInfo>, IDelegationInfoService
    {
        public DelegationInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfDelegationInfo> AddOrUpdate(ProfDelegationInfo delegationInfo)
        {
            try
            {
                ProfDelegationInfo result;
                if (delegationInfo.DelegationInfoId > 0)
                {
                    result = await UpdateAsync(delegationInfo);
                }
                else
                {
                    result = await AddAsync(delegationInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int delegationInfoId)
        {
            var result = await DeleteAsync(x=>x.DelegationInfoId == delegationInfoId);
            return result;
        }

        public async Task<ProfDelegationInfo> GetById(int delegationInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.DelegationInfoId == delegationInfoId);
            if (checkVal)
            {
                ProfDelegationInfo result = await GetByIdAsync(delegationInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfDelegationInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfDelegationInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
