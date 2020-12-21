using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.LU;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.LU
{

    public class SectionNameService : Repository<SectionName>, ISectionNameService
    {
        public SectionNameService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<SectionName>> GetAll()
        {
            IEnumerable<SectionName> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<SectionName> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.SectionNameId == id);
            if (checkVal)
            {
                SectionName result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<SectionName> AddOrUpdate(SectionName data)
        {
            try
            {
                SectionName result;
                if (data.SectionNameId > 0)
                {
                    result = await UpdateAsync(data);
                }
                else
                {
                    result = await AddAsync(data);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int id)
        {
            var result = await DeleteAsync(x => x.SectionNameId == id);
            return result;
        }
    }

}


