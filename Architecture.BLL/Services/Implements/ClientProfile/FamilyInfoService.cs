using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class FamilyInfoService : IFamilyInfoService
    {
        public IRepository<ProfFamilyInfo> familyInfoRepo;
        public async Task<ProfFamilyInfo> AddOrUpdate(ProfFamilyInfo familyInfo)
        {
            try
            {
                ProfFamilyInfo result;
                if (familyInfo.FamilyInfoId > 0)
                {
                    result = await familyInfoRepo.UpdateAsync(familyInfo);
                }
                else
                {
                    result = await familyInfoRepo.AddAsync(familyInfo);
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
            var result = await familyInfoRepo.DeleteAsync(x=>x.FamilyInfoId== familyInfoId);
            return result;
        }

        public async Task<ProfFamilyInfo> GetById(int familyInfoId)
        {
            var checkVal =await familyInfoRepo.IsExistsAsync(x=>x.FamilyInfoId== familyInfoId);
            if (checkVal)
            {
                ProfFamilyInfo result = await familyInfoRepo.GetByIdAsync(familyInfoId);
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
              result=await familyInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
