﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.LU;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.LU
{

    public class JobTypeService : Repository<JobType>, IJobTypeService
    {
        public JobTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<JobType>> GetAll()
        {
            IEnumerable<JobType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<JobType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.JobTypeId == id);
            if (checkVal)
            {
                JobType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<JobType> AddOrUpdate(JobType data)
        {
            try
            {
                JobType result;
                if (data.JobTypeId > 0)
                {
                    result = await UpdateAsync(data);
                }
                else
                {
                    result = await AddAsync(data);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int id)
        {
            var result = await DeleteAsync(x => x.JobTypeId == id);
            return result;
        }
    }

}

