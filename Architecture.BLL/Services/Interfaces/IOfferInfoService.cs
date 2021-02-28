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
    }
}
