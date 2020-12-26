using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Context;
using Architecture.BLL.Services.Interfaces;

namespace Architecture.BLL.Services.Implements
{

    public class SectionLinkService : Repository<SectionLink>, ISectionLinkService
    {

        private readonly ICurrentUserService currentUserService;

        public SectionLinkService(ApplicationDbContext dbContext) : base(dbContext)
        {
           
        }

        public async Task<IEnumerable<SectionLink>> GetAll()
        {
            IEnumerable<SectionLink> result;
            result = await GetAsync(x => x, null, null, x=> x.Include(y=> y.SectionName));
            return result;
        }


        public async Task<SectionLink> GetById(int sectionLinkId)
        {
            var checkVal = await IsExistsAsync(x => x.SectionLinkId == sectionLinkId);
            if (checkVal)
            {
                SectionLink result = await GetByIdAsync(sectionLinkId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<SectionLink> AddOrUpdate(SectionLink sectionLink)
        {
            try
            {
                SectionLink result;
                if (sectionLink.SectionLinkId > 0)
                {
                    result = await UpdateAsync(sectionLink);
                }
                else
                {
                    result = await AddAsync(sectionLink);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int sectionLinkId)
        {
            var result = await DeleteAsync(x => x.SectionLinkId == sectionLinkId);
            return result;
        }
    }
}
