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
    public class IncomeInfoService : Repository<ProfIncomeInfo>, IIncomeInfoService
    {

        public IncomeInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfIncomeInfo> AddOrUpdate(ProfIncomeInfo incomeInfo)
        {
            try
            {
                ProfIncomeInfo result;
                if (incomeInfo.IncomeInfoId > 0)
                {
                    result = await UpdateAsync(incomeInfo);
                }
                else
                {
                    result = await AddAsync(incomeInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int incomeInfoId)
        {
            var result = await DeleteAsync(x=>x.IncomeInfoId == incomeInfoId);
            return result;
        }

        public async Task<ProfIncomeInfo> GetById(int profileId, int incomeInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.IncomeInfoId == incomeInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfIncomeInfo result = await GetByIdAsync(incomeInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfIncomeInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfIncomeInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId, null, x => x.Include(y => y.IncomeType));
            return result;

        }
    }
}
