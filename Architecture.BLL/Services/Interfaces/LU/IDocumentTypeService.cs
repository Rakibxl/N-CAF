using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
   public interface IDocumentTypeService
    {
        Task<IEnumerable<DocumentType>> GetAll();
        Task<DocumentType> GetById(int id);
        Task<DocumentType> AddOrUpdate(DocumentType data);
        Task<int> Delete(int id);

    }
}
