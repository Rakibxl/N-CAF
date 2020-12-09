using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Architecture.Core.Common.Enums;
using Architecture.Core.Repository.Extensions;
using Architecture.BLL.Services.Exceptions;
using Architecture.Core.Common.Constants;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Query;
using Architecture.Core.Common.Helpers;
using System.IO;
using iTextSharp.text.pdf;
using Architecture.Core.Repository.Interfaces;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Context;
using Architecture.BLL.Services.Interfaces;

namespace Architecture.BLL.Services.Implements
{

    public class BranchService : Repository<BranchInfo>, IBranchService
    {
        public BranchService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<BranchInfo>> GetAll()
        {
            IEnumerable<BranchInfo> result;
            result = await GetAsync(x => x);
            return result;
        }

        public async Task<BranchInfo> GetById(int branchId)
        {
            var checkVal = await IsExistsAsync(x => x.BranchId == branchId);
            if (checkVal)
            {
                BranchInfo result = await GetByIdAsync(branchId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<BranchInfo> AddOrUpdate(BranchInfo branch)
        {
            try
            {
                BranchInfo result;
                if (branch.BranchId > 0)
                {
                    result = await UpdateAsync(branch);
                }
                else
                {
                    result = await AddAsync(branch);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int branchId)
        {
            var result = await DeleteAsync(x => x.BranchId == branchId);
            return result;
        }
    }
}
