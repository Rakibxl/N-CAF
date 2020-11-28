using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.Core.Entities.LU;

namespace Architecture.BLL.Services.Implements.LU
{
    interface IAddressTypeService
    {
        Task<IEnumerable<AddressType>> GetAll();
        Task<AddressType> GetById(int id);
        Task<AddressType> AddOrUpdate(AddressType addressType);
        Task<int> Delete(int id);

    }
}
