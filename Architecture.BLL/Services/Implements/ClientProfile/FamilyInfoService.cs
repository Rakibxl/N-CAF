using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class FamilyInfoService :Repository<ProfFamilyInfo>, IFamilyInfoService
    {
       
        public FamilyInfoService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ProfFamilyInfo> AddOrUpdate(ProfFamilyInfo familyInfo)
        {
            try
            {
                ProfFamilyInfo result;
                if (familyInfo.FamilyInfoId > 0)
                {
                    result = await UpdateAsync(familyInfo);
                }
                else
                {
                    result = await AddAsync(familyInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int familyInfoId)
        {
            var result = await DeleteAsync(x=>x.FamilyInfoId== familyInfoId);
            return result;
        }

        public async Task<ProfFamilyInfo> GetById(int profileId, int familyInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.FamilyInfoId== familyInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfFamilyInfo result = await GetByIdAsync(familyInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfFamilyInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfFamilyInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
