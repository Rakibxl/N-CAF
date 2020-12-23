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
    public class LegalInfoService : Repository<ProfLegalInfo>, ILegalInfoService
    {
        public LegalInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfLegalInfo> AddOrUpdate(ProfLegalInfo legalInfo)
        {
            try
            {
                ProfLegalInfo result;
                if (legalInfo.LegalInfoId > 0)
                {
                    result = await UpdateAsync(legalInfo);
                }
                else
                {
                    result = await AddAsync(legalInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int legalInfoId)
        {
            var result = await DeleteAsync(x=>x.LegalInfoId == legalInfoId);
            return result;
        }

        public async Task<ProfLegalInfo> GetById(int profileId, int legalInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.LegalInfoId == legalInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfLegalInfo result = await GetByIdAsync(legalInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfLegalInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfLegalInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId,null, x => x.Include(y => y.CountryName));
            return result;

        }
    }
}
