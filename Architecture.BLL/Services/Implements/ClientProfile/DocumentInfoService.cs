using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Core;

namespace Architecture.BLL.Services.Implements.ClientProfile
{
    public class DocumentInfoService : IDocumentInfoService
    {
        public IRepository<ProfDocumentInfo> documentInfoRepo;
        public async Task<ProfDocumentInfo> AddOrUpdate(ProfDocumentInfo documentInfo)
        {
            try
            {
                ProfDocumentInfo result;
                if (documentInfo.DocumentInfoId > 0)
                {
                    result = await documentInfoRepo.UpdateAsync(documentInfo);
                }
                else
                {
                    result = await documentInfoRepo.AddAsync(documentInfo);
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
            var result = await documentInfoRepo.DeleteAsync(x=>x.DocumentInfoId == documentInfoId);
            return result;
        }

        public async Task<ProfDocumentInfo> GetById(int documentInfoId)
        {
            var checkVal =await documentInfoRepo.IsExistsAsync(x=>x.DocumentInfoId == documentInfoId);
            if (checkVal)
            {
                ProfDocumentInfo result = await documentInfoRepo.GetByIdAsync(documentInfoId);
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
              result=await documentInfoRepo.GetAsync(x => x,x => x.ProfileId== profileId);
            return result;

        }
    }
}
