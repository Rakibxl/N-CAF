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

    public class RelationTypeService : Repository<RelationType>, IRelationTypeService
    {
        public RelationTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<RelationType>> GetAll()
        {
            IEnumerable<RelationType> result;
            result = await GetAsync(x => x, x => x.IsActive);
            return result;
        }

        public async Task<RelationType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.RelationTypeId == id);
            if (checkVal)
            {
                RelationType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<RelationType> AddOrUpdate(RelationType data)
        {
            try
            {
                RelationType result;
                if (data.RelationTypeId > 0)
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
            var result = await DeleteAsync(x => x.RelationTypeId == id);
            return result;
        }
    }

}


