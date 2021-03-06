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
    public class MovementInfoService : Repository<ProfMovementInfo>, IMovementInfoService
    {
        public MovementInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfMovementInfo> AddOrUpdate(ProfMovementInfo movementInfo)
        {
            try
            {
                ProfMovementInfo result;
                if (movementInfo.MovementInfoId > 0)
                {
                    result = await UpdateAsync(movementInfo);
                }
                else
                {
                    result = await AddAsync(movementInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int movementInfoId)
        {
            var result = await DeleteAsync(x=>x.MovementInfoId == movementInfoId);
            return result;
        }

        public async Task<ProfMovementInfo> GetById(int profileId, int movementInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.MovementInfoId == movementInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfMovementInfo result = await GetByIdAsync(movementInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfMovementInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfMovementInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId, null, x => x.Include(y => y.CountryName));
            return result;

        }
    }
}
