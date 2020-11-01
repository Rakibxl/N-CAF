using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IDocumentInfoService
    {
        public Task<ProfDocumentInfo> AddOrUpdate(ProfDocumentInfo documentInfo);
        public Task<ProfDocumentInfo> GetById(int documentInfoId);
        public Task<int> Delete(int documentInfoId);
        public Task<IEnumerable<ProfDocumentInfo>> GetAll(int profileId);
    }
}
