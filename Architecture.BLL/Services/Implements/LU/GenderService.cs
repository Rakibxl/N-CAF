
using Architecture.BLL.Services.Interfaces.LU;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements.LU
{
    public class GenderService : Repository<Gender>, IGenderService
    {
        public GenderService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Gender>> GetAll()
        {
            IEnumerable<Gender> result;
            result = await GetAsync(x => x,x=>x.IsActive==true);
            return result;
        }

        public async Task<Gender> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.GenderId == id);
            if (checkVal)
            {
                Gender result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<Gender> AddOrUpdate(Gender data)
        {
            try
            {
                Gender result;
                if (data.GenderId > 0)
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
            var result = await DeleteAsync(x => x.GenderId == id);
            return result;
        }
    }

}


