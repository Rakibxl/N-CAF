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

    public class NationalityService : Repository<Nationality>, INationalityService
    {
        public NationalityService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Nationality>> GetAll()
        {
            IEnumerable<Nationality> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<Nationality> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.NationalityId == id);
            if (checkVal)
            {
                Nationality result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<Nationality> AddOrUpdate(Nationality data)
        {
            try
            {
                Nationality result;
                if (data.NationalityId > 0)
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
            var result = await DeleteAsync(x => x.NationalityId == id);
            return result;
        }
    }

}


