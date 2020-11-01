using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class InsuranceInfoService : IInsuranceInfoService
    {
        public IRepository<ProfInsuranceInfo> insuranceInfoRepo;
        public async Task<ProfInsuranceInfo> AddOrUpdate(ProfInsuranceInfo insuranceInfo)
        {
            try
            {
                ProfInsuranceInfo result;
                if (insuranceInfo.InsuranceInfoId > 0)
                {
                    result = await insuranceInfoRepo.UpdateAsync(insuranceInfo);
                }
                else
                {
                    result = await insuranceInfoRepo.AddAsync(insuranceInfo);
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
            var result = await insuranceInfoRepo.DeleteAsync(x=>x.InsuranceInfoId == insuranceInfoId);
            return result;
        }

        public async Task<ProfInsuranceInfo> GetById(int insuranceInfoId)
        {
            var checkVal =await insuranceInfoRepo.IsExistsAsync(x=>x.InsuranceInfoId == insuranceInfoId);
            if (checkVal)
            {
                ProfInsuranceInfo result = await insuranceInfoRepo.GetByIdAsync(insuranceInfoId);
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
              result=await insuranceInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
