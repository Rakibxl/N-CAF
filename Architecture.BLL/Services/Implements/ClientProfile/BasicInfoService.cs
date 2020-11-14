using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Architecture.Core.Common.Enums;
using Architecture.Core.Repository.Extensions;
using Architecture.BLL.Services.Exceptions;
using Architecture.Core.Common.Constants;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Query;
using Architecture.Core.Common.Helpers;
using System.IO;
using iTextSharp.text.pdf;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Repository.Interfaces;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Context;

namespace Architecture.BLL.Services.Implements.ClientProfile
{

    public class BasicInfoService : Repository<ProfBasicInfo>, IBasicInfoService
    {

        public BasicInfoService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ProfBasicInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfBasicInfo> result;
            result = await GetAsync(x => x, x => x.ProfileId == profileId);
            return result;
        }

        public async Task<ProfBasicInfo> GetById(int basicInfoId)
        {
            var checkVal = await IsExistsAsync(x => x.ProfileId == basicInfoId);
            if (checkVal)
            {
                ProfBasicInfo result = await GetByIdAsync(basicInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }

        }

        public async Task<ProfBasicInfo> AddOrUpdate(ProfBasicInfo basicInfo)
        {
            try
            {
                ProfBasicInfo result;
                if (basicInfo.ProfileId > 0)
                {
                    result = await UpdateAsync(basicInfo);
                }
                else
                {
                    result = await AddAsync(basicInfo);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int basicInfoId)
        {
            var result = await DeleteAsync(x => x.ProfileId == basicInfoId);
            return result;
        }
    }
}
