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
    public class WorkerInfoService : Repository<ProfWorkerInfo>, IWorkerInfoService
    {
        public WorkerInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfWorkerInfo> AddOrUpdate(ProfWorkerInfo workerInfo)
        {
            try
            {
                ProfWorkerInfo result;
                if (workerInfo.WorkerInfoId > 0)
                {
                    result = await UpdateAsync(workerInfo);
                }
                else
                {
                    result = await AddAsync(workerInfo);
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
            var result = await DeleteAsync(x=>x.WorkerInfoId == workerInfoId);
            return result;
        }

        public async Task<ProfWorkerInfo> GetById(int profileId, int workerInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.WorkerInfoId == workerInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfWorkerInfo result = await GetByIdAsync(workerInfoId);
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
              result=await GetAsync(x => x,x => x.ProfileId== profileId, null, x => x.Include(y => y.WorkerType));
            return result;

        }
    }
}
