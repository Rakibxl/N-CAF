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

    public class ResidenceScopeService : Repository<ResidenceScope>, IResidenceScopeService
    {
        public ResidenceScopeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<ResidenceScope>> GetAll()
        {
            IEnumerable<ResidenceScope> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<ResidenceScope> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.ResidenceScopeId == id);
            if (checkVal)
            {
                ResidenceScope result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<ResidenceScope> AddOrUpdate(ResidenceScope data)
        {
            try
            {
                ResidenceScope result;
                if (data.ResidenceScopeId > 0)
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
            var result = await DeleteAsync(x => x.ResidenceScopeId == id);
            return result;
        }
    }

}


