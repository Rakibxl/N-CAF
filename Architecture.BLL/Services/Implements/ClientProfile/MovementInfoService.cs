using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class MovementInfoService : IMovementInfoService
    {
        public IRepository<ProfMovementInfo> movementInfoRepo;
        public async Task<ProfMovementInfo> AddOrUpdate(ProfMovementInfo movementInfo)
        {
            try
            {
                ProfMovementInfo result;
                if (movementInfo.MovementInfoId > 0)
                {
                    result = await movementInfoRepo.UpdateAsync(movementInfo);
                }
                else
                {
                    result = await movementInfoRepo.AddAsync(movementInfo);
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
            var result = await movementInfoRepo.DeleteAsync(x=>x.MovementInfoId == movementInfoId);
            return result;
        }

        public async Task<ProfMovementInfo> GetById(int movementInfoId)
        {
            var checkVal =await movementInfoRepo.IsExistsAsync(x=>x.MovementInfoId == movementInfoId);
            if (checkVal)
            {
                ProfMovementInfo result = await movementInfoRepo.GetByIdAsync(movementInfoId);
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
              result=await movementInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
