using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IBankInfoService
    {
        public Task<ProfBankInfo> AddOrUpdate(ProfBankInfo bankInfo);
        public Task<ProfBankInfo> GetById(int profileId, int bankInfoId);
        public Task<int> Delete(int bankInfoId);
        public Task<IEnumerable<ProfBankInfo>> GetAll(int profileId);
    }
}
