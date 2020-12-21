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

    public class OccupationPositionService : Repository<OccupationPosition>, IOccupationPositionService
    {
        public OccupationPositionService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<OccupationPosition>> GetAll()
        {
            IEnumerable<OccupationPosition> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<OccupationPosition> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.OccupationPositionId == id);
            if (checkVal)
            {
                OccupationPosition result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<OccupationPosition> AddOrUpdate(OccupationPosition data)
        {
            try
            {
                OccupationPosition result;
                if (data.OccupationPositionId > 0)
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
            var result = await DeleteAsync(x => x.OccupationPositionId == id);
            return result;
        }
    }

}


