using Architecture.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
    public interface ISectionLinkService
    {
        public Task<IEnumerable<SectionLink>> GetAll();
        public Task<SectionLink> GetById(int sectionLinkId);
        public Task<List<SectionLink>> GetBySectionName(string sectionName);
        public Task<SectionLink> AddOrUpdate(SectionLink questionInfo);
        public Task<int> Delete(int questionInfoId);
    }
}
