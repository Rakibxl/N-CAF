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

    public class CountryNameService : Repository<CountryName>, ICountryNameService
    {
        public CountryNameService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<CountryName>> GetAll()
        {
            IEnumerable<CountryName> result;
            result = await GetAsync(x => x);
            return result;
        }

        public async Task<CountryName> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.CountryNameId == id);
            if (checkVal)
            {
                CountryName result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<CountryName> AddOrUpdate(CountryName data)
        {
            try
            {
                CountryName result;
                if (data.CountryNameId > 0)
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
            var result = await DeleteAsync(x => x.CountryNameId == id);
            return result;
        }
    }

}
