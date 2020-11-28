using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class HouseRentInfoService :  Repository<ProfHouseRentInfo>,IHouseRentInfoService
    {
        public HouseRentInfoService(ApplicationDbContext context): base(context)
        {

        }

        public async Task<ProfHouseRentInfo> AddOrUpdate(ProfHouseRentInfo houserentInfo)
        {
            try
            {
                ProfHouseRentInfo result;
                if (houserentInfo.HouseRentInfoId > 0)
                {
                    result = await UpdateAsync(houserentInfo);
                }
                else
                {
                    result = await AddAsync(houserentInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int houserentInfoId)
        {
            try
            {
                var info = await GetByIdAsync(houserentInfoId);
                info.RecordStatusId = 2;
                var result = await UpdateAsync(info);
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<ProfHouseRentInfo> GetById(int houserentInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.HouseRentInfoId == houserentInfoId);
            if (checkVal)
            {
                ProfHouseRentInfo result = await GetByIdAsync(houserentInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfHouseRentInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfHouseRentInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
