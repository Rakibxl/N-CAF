using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class InsuranceInfoService : Repository<ProfInsuranceInfo>, IInsuranceInfoService
    {

        public InsuranceInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfInsuranceInfo> AddOrUpdate(ProfInsuranceInfo insuranceInfo)
        {
            try
            {
                ProfInsuranceInfo result;
                if (insuranceInfo.InsuranceInfoId > 0)
                {
                    result = await UpdateAsync(insuranceInfo);
                }
                else
                {
                    result = await AddAsync(insuranceInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int insuranceInfoId)
        {
            var result = await DeleteAsync(x=>x.InsuranceInfoId == insuranceInfoId);
            return result;
        }

        public async Task<ProfInsuranceInfo> GetById(int insuranceInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.InsuranceInfoId == insuranceInfoId);
            if (checkVal)
            {
                ProfInsuranceInfo result = await GetByIdAsync(insuranceInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfInsuranceInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfInsuranceInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
