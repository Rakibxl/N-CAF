using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IIncomeInfoService
    {
        public Task<ProfIncomeInfo> AddOrUpdate(ProfIncomeInfo incomeInfo);
        public Task<ProfIncomeInfo> GetById(int profileId, int incomeInfoId);
        public Task<int> Delete(int incomeInfoId);
        public Task<IEnumerable<ProfIncomeInfo>> GetAll(int profileId);
    }
}
