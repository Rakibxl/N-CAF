using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class OccupationInfoService : Repository<ProfOccupationInfo>, IOccupationInfoService
    {
        public OccupationInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfOccupationInfo> AddOrUpdate(ProfOccupationInfo occupationInfo)
        {
            try
            {
                ProfOccupationInfo result;
                if (occupationInfo.OccupationInfoId > 0)
                {
                    result = await UpdateAsync(occupationInfo);
                }
                else
                {
                    result = await AddAsync(occupationInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int occupationInfoId)
        {
            var result = await DeleteAsync(x=>x.OccupationInfoId == occupationInfoId);
            return result;
        }

        public async Task<ProfOccupationInfo> GetById(int occupationInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.OccupationInfoId == occupationInfoId);
            if (checkVal)
            {
                ProfOccupationInfo result = await GetByIdAsync(occupationInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfOccupationInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfOccupationInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
