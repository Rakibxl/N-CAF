using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class EducationInfoService : IEducationInfoService
    {
        public IRepository<ProfEducationInfo> educationInfoRepo;
        public async Task<ProfEducationInfo> AddOrUpdate(ProfEducationInfo educationInfo)
        {
            try
            {
                ProfEducationInfo result;
                if (educationInfo.EducationInfoId > 0)
                {
                    result = await educationInfoRepo.UpdateAsync(educationInfo);
                }
                else
                {
                    result = await educationInfoRepo.AddAsync(educationInfo);
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
            var result = await educationInfoRepo.DeleteAsync(x=>x.EducationInfoId == educationInfoId);
            return result;
        }

        public async Task<ProfEducationInfo> GetById(int educationInfoId)
        {
            var checkVal =await educationInfoRepo.IsExistsAsync(x=>x.EducationInfoId == educationInfoId);
            if (checkVal)
            {
                ProfEducationInfo result = await educationInfoRepo.GetByIdAsync(educationInfoId);
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
              result=await educationInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
