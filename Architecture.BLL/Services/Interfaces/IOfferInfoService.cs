using Architecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
   public interface IOfferInfoService
    {
        Task<IEnumerable<JobInfo>> GetMyOffer();
        Task<OfferInfo> GetById(int offerInfoId);
        dynamic GetCurrentStatusById(int profileId);
        Task<OfferInfo> AddOrUpdate(OfferInfo offerInfo);
        Task<int> Delete(int offerInfoId);
    }
}
