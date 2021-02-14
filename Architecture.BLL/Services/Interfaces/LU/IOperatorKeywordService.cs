using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements.LU
{
    public interface IOperatorKeywordService
    {
        Task<IEnumerable<OperatorKeyword>> GetAll();
        Task<OperatorKeyword> GetById(int id);
        Task<OperatorKeyword> AddOrUpdate(OperatorKeyword operatorKeyword);
        Task<int> Delete(int id);
    }
}
