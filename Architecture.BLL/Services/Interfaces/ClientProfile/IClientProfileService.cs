using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.ClientProfile.Interfaces
{
    public interface IClientProfileService
    {
        Task<int> AddUpdate(ProfBasicInfo entity);
    }
}
