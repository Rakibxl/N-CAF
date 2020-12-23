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
    public class AddressInfoService : Repository<ProfAddressInfo>, IAddressInfoService
    {
        public AddressInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfAddressInfo> AddOrUpdate(ProfAddressInfo addressInfo)
        {
            try
            {
                ProfAddressInfo result;
                if (addressInfo.AddressInfoId > 0)
                {
                    result = await UpdateAsync(addressInfo);
                }
                else
                {
                    result = await AddAsync(addressInfo);
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
            var result = await DeleteAsync(x=>x.AddressInfoId == addressInfoId);
            return result;
        }

        public async Task<ProfAddressInfo> GetById(int profileId, int addressInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.AddressInfoId == addressInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfAddressInfo result = await GetByIdAsync(addressInfoId);
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
              result=await GetAsync(x => x,x => x.ProfileId== profileId, null, x => x.Include(y => y.AddressType));
            return result;

        }
    }
}
