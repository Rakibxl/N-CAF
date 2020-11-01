using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class BankInfoService : IBankInfoService
    {
        public IRepository<ProfBankInfo> bankInfoRepo;
        public async Task<ProfBankInfo> AddOrUpdate(ProfBankInfo bankInfo)
        {
            try
            {
                ProfBankInfo result;
                if (bankInfo.BankInfoId > 0)
                {
                    result = await bankInfoRepo.UpdateAsync(bankInfo);
                }
                else
                {
                    result = await bankInfoRepo.AddAsync(bankInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int bankInfoId)
        {
            var result = await bankInfoRepo.DeleteAsync(x=>x.BankInfoId == bankInfoId);
            return result;
        }

        public async Task<ProfBankInfo> GetById(int bankInfoId)
        {
            var checkVal =await bankInfoRepo.IsExistsAsync(x=>x.BankInfoId == bankInfoId);
            if (checkVal)
            {
                ProfBankInfo result = await bankInfoRepo.GetByIdAsync(bankInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfBankInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfBankInfo> result;
              result=await bankInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
