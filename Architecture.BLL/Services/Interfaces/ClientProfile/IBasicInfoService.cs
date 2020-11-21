using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.ClientProfile
{
    public interface IBasicInfoService
    {
        public Task<IEnumerable<ProfBasicInfo>> GetAll(int profileId);
        public Task<ProfBasicInfo> GetById(int profileId);
        public Task<ProfBasicInfo> GetByRefId(Guid UserId);
        public Task<ProfBasicInfo> AddOrUpdate(ProfBasicInfo basicInfo);
        public Task<int> Delete(int profileId);
    }
}
