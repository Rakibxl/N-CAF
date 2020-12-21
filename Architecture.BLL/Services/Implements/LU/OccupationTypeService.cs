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

    public class OccupationTypeService : Repository<OccupationType>, IOccupationTypeService
    {
        public OccupationTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<OccupationType>> GetAll()
        {
            IEnumerable<OccupationType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<OccupationType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.OccupationTypeId == id);
            if (checkVal)
            {
                OccupationType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<OccupationType> AddOrUpdate(OccupationType data)
        {
            try
            {
                OccupationType result;
                if (data.OccupationTypeId > 0)
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
            var result = await DeleteAsync(x => x.OccupationTypeId == id);
            return result;
        }
    }

}


