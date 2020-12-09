using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
    public interface IBranchService
    {
        public Task<IEnumerable<BranchInfo>> GetAll();
        public Task<BranchInfo> GetById(int branchId);
        public Task<BranchInfo> AddOrUpdate(BranchInfo branch);
        public Task<int> Delete(int branchId);
    }
}
