using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
    public interface IExampleService : IDisposable
    {
        Task<QueryResult<Example>> GetAllAsync(ExampleQuery queryObj);
        Task<IList<Example>> GetAllActiveAsync();
        Task<Example> GetByIdAsync(int id);
        Task<int> AddAsync(Example entity);
        Task<int> UpdateAsync(Example entity);
        Task<bool> ActiveInactiveAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> IsExistsNameAsync(string name, int id);
    }
}
