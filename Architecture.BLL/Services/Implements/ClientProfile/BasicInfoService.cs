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
using Architecture.Core.Repository.Interfaces;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Context;
using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using System.Security.Claims;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class BasicInfoService : Repository<ProfBasicInfo>, IBasicInfoService
    {
        private readonly ICurrentUserService _currentUserService;

        public BasicInfoService(ApplicationDbContext dbContext, ICurrentUserService currentUserService) : base(dbContext)
        {
            _currentUserService = currentUserService;
        }

        public async Task<IEnumerable<ProfBasicInfo>> GetAll()
        {
            IEnumerable<ProfBasicInfo> result;
            result = await GetAsync(x => x, x => x.RefId == _currentUserService.UserId);
            return result;
        }

        public async Task<ProfBasicInfo> GetById(int profileId)
        {
            var checkVal = await IsExistsAsync(x => x.ProfileId == profileId);
            if (checkVal)
            {
                ProfBasicInfo result = await GetByIdAsync(profileId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<ProfBasicInfo> GetCurrentUserBasicInfo()
        {
            
            var checkVal = await IsExistsAsync(x => x.RefId == _currentUserService.UserId);
            if (checkVal)
            {
                IEnumerable<ProfBasicInfo> result = await GetAsync(x => x, x => x.RefId == _currentUserService.UserId);
                return result.FirstOrDefault();
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
                    basicInfo.BranchInfoId= (_currentUserService.BranchInfoId!=null && _currentUserService.BranchInfoId != "") ? int.Parse( _currentUserService.BranchInfoId) : null;                    
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

        public async Task<ProfBasicInfo> GetBasicWithIncludeAll()
        {
            ProfBasicInfo result = new ProfBasicInfo();

          
            if (_currentUserService.UserTypeId ==(int) EnumApplicationUserType.Admin)  // client type user
            {
                result = await GetFirstOrDefaultAsync(x => x, x => x.RefId == _currentUserService.UserId, x => x.Include(y => y.ProfBankInfos)
                                                                                                                .Include(y => y.ProfOccupationInfos)
                                                                                                                .Include(y => y.ProfFamilyInfos)
                                                                                                                .Include(y => y.ProfEducationInfos)
                                                                                                                .Include(y => y.ProfAddressInfos)
                                                                                                                .Include(y => y.ProfHouseRentInfos)
                                                                                                                .Include(y => y.ProfDocumentInfos)
                                                                                                                .Include(y => y.ProfIncomeInfos)
                                                                                                                .Include(y => y.ProfAssetInfos)
                                                                                                                .Include(y => y.ProfInsuranceInfos)
                                                                                                                .Include(y => y.ProfISEEInfos)
                                                                                                                .Include(y => y.ProfLegalInfos)
                                                                                                                .Include(y => y.ProfMovementInfos)
                                                                                                                .Include(y => y.ProfWorkerInfos)
                                                                                                                .Include(y => y.ProfDelegationInfos));
            }
 
            return result;

        }
    }
}
