using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.Core.Entities;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IHouseRentInfoService
    {
        public Task<ProfHouseRentInfo> AddOrUpdate(ProfHouseRentInfo houserentInfo);
        public Task<ProfHouseRentInfo> GetById(int profileId, int houserentInfoId);
        public Task<int> Delete(int houserentInfoId);
        public Task<IEnumerable<ProfHouseRentInfo>> GetAll(int profileId);
    }
}
