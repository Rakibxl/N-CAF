using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IAddressInfoService
    {
        public Task<ProfAddressInfo> AddOrUpdate(ProfAddressInfo familyInfo);
        public Task<ProfAddressInfo> GetById(int familyInfoId);
        public Task<int> Delete(int familyInfoId);
        public Task<IEnumerable<ProfAddressInfo>> GetAll(int profileId);
    }
}
