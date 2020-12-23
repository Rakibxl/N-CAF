using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class BankInfoService : Repository<ProfBankInfo>, IBankInfoService
    {
        public BankInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfBankInfo> AddOrUpdate(ProfBankInfo bankInfo)
        {
            try
            {
                ProfBankInfo result;
                if (bankInfo.BankInfoId > 0)
                {
                    result = await UpdateAsync(bankInfo);
                }
                else
                {
                    result = await AddAsync(bankInfo);
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
            var result = await DeleteAsync(x=>x.BankInfoId == bankInfoId);
            return result;
        }

        public async Task<ProfBankInfo> GetById(int profileId,int bankInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.BankInfoId == bankInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfBankInfo result = await GetByIdAsync(bankInfoId);
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
              result=await GetAsync(x => x,x => x.ProfileId== profileId, null, x => x.Include(y => y.BankName));
            return result;

        }
    }
}
