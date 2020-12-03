using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class EducationInfoService :  Repository<ProfEducationInfo>, IEducationInfoService
    {

        public EducationInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfEducationInfo> AddOrUpdate(ProfEducationInfo educationInfo)
        {
            try
            {
                ProfEducationInfo result;
                if (educationInfo.EducationInfoId > 0)
                {
                    result = await UpdateAsync(educationInfo);
                }
                else
                {
                    result = await AddAsync(educationInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int educationInfoId)
        {
            var result = await DeleteAsync(x=>x.EducationInfoId == educationInfoId);
            return result;
        }

        public async Task<ProfEducationInfo> GetById(int profileId, int educationInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.EducationInfoId == educationInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfEducationInfo result = await GetByIdAsync(educationInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfEducationInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfEducationInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
