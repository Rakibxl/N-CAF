using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class WorkerInfoService : IWorkerInfoService
    {
        public IRepository<ProfWorkerInfo> workerInfoRepo;
        public async Task<ProfWorkerInfo> AddOrUpdate(ProfWorkerInfo workerInfo)
        {
            try
            {
                ProfWorkerInfo result;
                if (workerInfo.WorkerInfoId > 0)
                {
                    result = await workerInfoRepo.UpdateAsync(workerInfo);
                }
                else
                {
                    result = await workerInfoRepo.AddAsync(workerInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int workerInfoId)
        {
            var result = await workerInfoRepo.DeleteAsync(x=>x.WorkerInfoId == workerInfoId);
            return result;
        }

        public async Task<ProfWorkerInfo> GetById(int workerInfoId)
        {
            var checkVal =await workerInfoRepo.IsExistsAsync(x=>x.WorkerInfoId == workerInfoId);
            if (checkVal)
            {
                ProfWorkerInfo result = await workerInfoRepo.GetByIdAsync(workerInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfWorkerInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfWorkerInfo> result;
              result=await workerInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
