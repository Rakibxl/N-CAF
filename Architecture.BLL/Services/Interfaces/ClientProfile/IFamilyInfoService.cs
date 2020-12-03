using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
   public interface IFamilyInfoService
    {
        public Task<ProfFamilyInfo> AddOrUpdate(ProfFamilyInfo familyInfo);
        public Task<ProfFamilyInfo> GetById(int profileId, int familyInfoId);
        public Task<int> Delete(int familyInfoId);
        public Task<IEnumerable<ProfFamilyInfo>> GetAll(int profileId);
    }
}
