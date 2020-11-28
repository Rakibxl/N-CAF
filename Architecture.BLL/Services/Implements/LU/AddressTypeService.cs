using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Implements.LU;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{

    public class AddressTypeService : Repository<AddressType>, IAddressTypeService
    {
        public AddressTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<AddressType>> GetAll()
        {
            IEnumerable<AddressType> result;
            result = await GetAsync(x => x,x=>x.IsActive==true);
            return result;
        }

        public async Task<AddressType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.AddressTypeId == id);
            if (checkVal)
            {
                AddressType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<AddressType> AddOrUpdate(AddressType addressType)
        {
            try
            {
                AddressType result;
                if (addressType.AddressTypeId > 0)
                {                    
                    result = await UpdateAsync(addressType);
                }
                else
                {
                    result = await AddAsync(addressType);
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
            var result = await DeleteAsync(x => x.AddressTypeId == id);
            return result;
        }
    }
}
