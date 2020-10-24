using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class AddressInfoService : IAddressInfoService
    {
        public IRepository<ProfAddressInfo> addressInfoRepo;
        public async Task<ProfAddressInfo> AddOrUpdate(ProfAddressInfo addressInfo)
        {
            try
            {
                ProfAddressInfo result;
                if (addressInfo.AddressInfoId > 0)
                {
                    result = await addressInfoRepo.UpdateAsync(addressInfo);
                }
                else
                {
                    result = await addressInfoRepo.AddAsync(addressInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int addressInfoId)
        {
            var result = await addressInfoRepo.DeleteAsync(x=>x.AddressInfoId == addressInfoId);
            return result;
        }

        public async Task<ProfAddressInfo> GetById(int addressInfoId)
        {
            var checkVal =await addressInfoRepo.IsExistsAsync(x=>x.AddressInfoId == addressInfoId);
            if (checkVal)
            {
                ProfAddressInfo result = await addressInfoRepo.GetByIdAsync(addressInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfAddressInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfAddressInfo> result;
              result=await addressInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
