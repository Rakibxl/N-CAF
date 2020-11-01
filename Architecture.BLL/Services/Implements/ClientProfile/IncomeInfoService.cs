using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class IncomeInfoService : IIncomeInfoService
    {
        public IRepository<ProfIncomeInfo> incomeInfoRepo;
        public async Task<ProfIncomeInfo> AddOrUpdate(ProfIncomeInfo incomeInfo)
        {
            try
            {
                ProfIncomeInfo result;
                if (incomeInfo.IncomeInfoId > 0)
                {
                    result = await incomeInfoRepo.UpdateAsync(incomeInfo);
                }
                else
                {
                    result = await incomeInfoRepo.AddAsync(incomeInfo);
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
            var result = await incomeInfoRepo.DeleteAsync(x=>x.IncomeInfoId == incomeInfoId);
            return result;
        }

        public async Task<ProfIncomeInfo> GetById(int incomeInfoId)
        {
            var checkVal =await incomeInfoRepo.IsExistsAsync(x=>x.IncomeInfoId == incomeInfoId);
            if (checkVal)
            {
                ProfIncomeInfo result = await incomeInfoRepo.GetByIdAsync(incomeInfoId);
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
              result=await incomeInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
