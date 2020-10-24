using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class ISEEInfoService : IISEEInfoService
    {
        public IRepository<ProfISEEInfo> iseeInfoRepo;
        public async Task<ProfISEEInfo> AddOrUpdate(ProfISEEInfo iseeInfo)
        {
            try
            {
                ProfISEEInfo result;
                if (iseeInfo.ISEEInfoId > 0)
                {
                    result = await iseeInfoRepo.UpdateAsync(iseeInfo);
                }
                else
                {
                    result = await iseeInfoRepo.AddAsync(iseeInfo);
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
            var result = await iseeInfoRepo.DeleteAsync(x=>x.ISEEInfoId == iseeInfoId);
            return result;
        }

        public async Task<ProfISEEInfo> GetById(int iseeInfoId)
        {
            var checkVal =await iseeInfoRepo.IsExistsAsync(x=>x.ISEEInfoId == iseeInfoId);
            if (checkVal)
            {
                ProfISEEInfo result = await iseeInfoRepo.GetByIdAsync(iseeInfoId);
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
              result=await iseeInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
