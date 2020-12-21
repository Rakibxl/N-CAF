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

    public class NationalIdTypeService : Repository<NationalIdType>, INationalIdTypeService
    {
        public NationalIdTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<NationalIdType>> GetAll()
        {
            IEnumerable<NationalIdType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<NationalIdType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.NationalIdTypeId == id);
            if (checkVal)
            {
                NationalIdType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<NationalIdType> AddOrUpdate(NationalIdType data)
        {
            try
            {
                NationalIdType result;
                if (data.NationalIdTypeId > 0)
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
            var result = await DeleteAsync(x => x.NationalIdTypeId == id);
            return result;
        }
    }

}


