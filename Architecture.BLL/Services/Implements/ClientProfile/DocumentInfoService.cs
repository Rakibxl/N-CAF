using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Microsoft.EntityFrameworkCore;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class DocumentInfoService : Repository<ProfDocumentInfo>,IDocumentInfoService
    {
        public DocumentInfoService(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<ProfDocumentInfo> AddOrUpdate(ProfDocumentInfo documentInfo)
        {
            try
            {
                ProfDocumentInfo result;
                if (documentInfo.DocumentInfoId > 0)
                {
                    result = await UpdateAsync(documentInfo);
                }
                else
                {
                    result = await AddAsync(documentInfo);
                }

                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<int> Delete(int documentInfoId)
        {
            var result = await DeleteAsync(x=>x.DocumentInfoId == documentInfoId);
            return result;
        }

        public async Task<ProfDocumentInfo> GetById(int profileId, int documentInfoId)
        {
            var checkVal =await IsExistsAsync(x=>x.DocumentInfoId == documentInfoId && x.ProfileId == profileId);
            if (checkVal)
            {
                ProfDocumentInfo result = await GetByIdAsync(documentInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
            
        }

        public async Task<IEnumerable<ProfDocumentInfo>> GetAll(int profileId)
        {
            IEnumerable<ProfDocumentInfo> result;
              result=await GetAsync(x => x,x => x.ProfileId== profileId,null, x => x.Include(y => y.DocumentType));
            return result;

        }
    }
}
