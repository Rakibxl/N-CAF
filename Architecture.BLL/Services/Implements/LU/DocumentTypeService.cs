using Architecture.BLL.Services.Interfaces.LU;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements.LU
{
    public class DocumentTypeService:Repository<DocumentType>, IDocumentTypeService
    {
        public DocumentTypeService(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<IEnumerable<DocumentType>> GetAll()
    {
        IEnumerable<DocumentType> result;
        result = await GetAsync(x => x,x=>x.IsActive);
        return result;
    }

    public async Task<DocumentType> GetById(int id)
    {
        var checkVal = await IsExistsAsync(x => x.DocumentTypeId == id);
        if (checkVal)
        {
            DocumentType result = await GetByIdAsync(id);
            return result;
        }
        else
        {
            throw new Exception("Information is not exists.");
        }
    }

    public async Task<DocumentType> AddOrUpdate(DocumentType data)
    {
        try
        {
            DocumentType result;
            if (data.DocumentTypeId > 0)
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
        var result = await DeleteAsync(x => x.DocumentTypeId == id);
        return result;
    }
}

}
