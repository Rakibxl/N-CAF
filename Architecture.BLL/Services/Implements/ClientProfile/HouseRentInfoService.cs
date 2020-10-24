using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class HouseRentInfoService : IHouseRentInfoService
    {
        public IRepository<ProfHouseRentInfo> houserentInfoRepo;
        public async Task<ProfHouseRentInfo> AddOrUpdate(ProfHouseRentInfo houserentInfo)
        {
            try
            {
                ProfHouseRentInfo result;
                if (houserentInfo.HouseRentInfoId > 0)
                {
                    result = await houserentInfoRepo.UpdateAsync(houserentInfo);
                }
                else
                {
                    result = await houserentInfoRepo.AddAsync(houserentInfo);
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
            var result = await houserentInfoRepo.DeleteAsync(x=>x.HouseRentInfoId == houserentInfoId);
            return result;
        }

        public async Task<ProfHouseRentInfo> GetById(int houserentInfoId)
        {
            var checkVal =await houserentInfoRepo.IsExistsAsync(x=>x.HouseRentInfoId == houserentInfoId);
            if (checkVal)
            {
                ProfHouseRentInfo result = await houserentInfoRepo.GetByIdAsync(houserentInfoId);
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
              result=await houserentInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
