﻿using Architecture.BLL.Services.Models;
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
        Task<IEnumerable<OfferInfoVM>> GetMyProgressOffer();
        Task<OfferInfo> GetById(int offerInfoId);
        dynamic GetCurrentStatusById(int profileId);
        Task<OfferInfo> AddOrUpdate(OfferInfo offerInfo);
        Task<int> Delete(int offerInfoId);

        #region operator
        Task<IEnumerable<OfferInfoVM>> GetOperatorPendingOffer();
        Task<IEnumerable<OfferInfoVM>> GetOperatorCompletedOffer();
        Task<IEnumerable<OfferInfoVM>> GetOperatorProgressOffer();
        Task<string> OperatorOfferAcceptRequest(int offerInfoId);
        Task<string> OperatorAcceptedOfferRevertRequest(int offerInfoId);
        Task<OfferInfo> OperatorChangeOfferStatusRequest(int profileId, int offerInfoId, string status);
        #endregion
    }
}
