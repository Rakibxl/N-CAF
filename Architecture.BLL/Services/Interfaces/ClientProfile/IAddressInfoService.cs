using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IAddressInfoService
    {
        public Task<ProfAddressInfo> AddOrUpdate(ProfAddressInfo addressInfo);
        public Task<ProfAddressInfo> GetById(int profileId, int addressInfoId);
        public Task<int> Delete(int addressInfoId);
        public Task<IEnumerable<ProfAddressInfo>> GetAll(int profileId);
    }
}
