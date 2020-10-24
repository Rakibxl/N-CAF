using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IInsuranceInfoService
    {
        public Task<ProfInsuranceInfo> AddOrUpdate(ProfInsuranceInfo insuranceInfo);
        public Task<ProfInsuranceInfo> GetById(int insuranceInfoId);
        public Task<int> Delete(int insuranceInfoId);
        public Task<IEnumerable<ProfInsuranceInfo>> GetAll(int profileId);
    }
}
