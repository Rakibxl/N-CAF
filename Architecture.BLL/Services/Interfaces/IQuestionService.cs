using Architecture.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
    public interface IQuestionService
    {
        public Task<IEnumerable<QuestionInfo>> GetAll();
        public Task<QuestionInfo> GetById(int questionInfoId);
        public Task<QuestionInfo> AddOrUpdate(QuestionInfo questionInfo);
        public Task<int> Delete(int questionInfoId);
    }
}
