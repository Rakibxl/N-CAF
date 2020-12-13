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

    public class DegreeTypeService : Repository<DegreeType>, ICRUDService<DegreeType>
    {
        public DegreeTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<DegreeType>> GetAll()
        {
            IEnumerable<DegreeType> result;
            result = await GetAsync(x => x);
            return result;
        }

        public async Task<DegreeType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.DegreeTypeId == id);
            if (checkVal)
            {
                DegreeType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<DegreeType> AddOrUpdate(DegreeType data)
        {
            try
            {
                DegreeType result;
                if (data.DegreeTypeId > 0)
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
            var result = await DeleteAsync(x => x.DegreeTypeId == id);
            return result;
        }
    }

}

