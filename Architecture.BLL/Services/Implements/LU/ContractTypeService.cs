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

    public class ContractTypeService : Repository<ContractType>, IContractTypeService
    {
        public ContractTypeService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<ContractType>> GetAll()
        {
            IEnumerable<ContractType> result;
            result = await GetAsync(x => x);
            return result;
        }

        public async Task<ContractType> GetById(int id)
        {
            var checkVal = await IsExistsAsync(x => x.ContractTypeId == id);
            if (checkVal)
            {
                ContractType result = await GetByIdAsync(id);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<ContractType> AddOrUpdate(ContractType data)
        {
            try
            {
                ContractType result;
                if (data.ContractTypeId > 0)
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
            var result = await DeleteAsync(x => x.ContractTypeId == id);
            return result;
        }
    }

}
