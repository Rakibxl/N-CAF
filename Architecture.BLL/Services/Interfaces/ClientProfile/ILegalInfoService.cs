using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface ILegalInfoService
    {
        public Task<ProfLegalInfo> AddOrUpdate(ProfLegalInfo legalInfo);
        public Task<ProfLegalInfo> GetById(int legalInfoId);
        public Task<int> Delete(int legalInfoId);
        public Task<IEnumerable<ProfLegalInfo>> GetAll(int profileId);
    }
}
