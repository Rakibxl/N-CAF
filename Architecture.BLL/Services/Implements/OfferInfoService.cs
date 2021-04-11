using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Architecture.BLL.Services.Models;
using System.Security.Claims;
using Architecture.Core.Common.Enums;

namespace Architecture.BLL.Services.Implements
{
    public class OfferInfoService: Repository<OfferInfo>, IOfferInfoService
    {
        private readonly IJobInformationService jobInformationService;
        private readonly ICurrentUserService CurrentUserService;
        private readonly IApplicationUserService applicationUserService;
        public OfferInfoService(ApplicationDbContext dbContext, IJobInformationService jobInformationService, ICurrentUserService CurrentUserService,
           IApplicationUserService applicationUserService) : base(dbContext)
        {
            this.jobInformationService = jobInformationService;
            this.CurrentUserService = CurrentUserService;
            this.applicationUserService = applicationUserService;
        }

        public async Task<IEnumerable<JobInfo>> GetMyOffer()
        {
            var result = await jobInformationService.GetAll();
            return result;
        }


        #region Operator
        public async Task<IEnumerable<OfferInfoVM>> GetOperatorProgressOffer()
        {
            var UserId = CurrentUserService.UserId.ToString();

            var result = from of in _dbContext.OfferInfos.Where(x => x.AcceptedOperatorId == UserId && (x.OfferStatusId == 3 || x.OfferStatusId == 4 || x.OfferStatusId == 6 || x.OfferStatusId == 7))
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId
                         join operatorObj in _dbContext.Users on of.AcceptedOperatorId equals operatorObj.Id.ToString()
                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = operatorObj.Name,
                             OfferStatusId = of.OfferStatusId,
                             OperatorAcceptedDate = of.OperatorAcceptedDate,
                             ValidatorId = of.ValidatorId,
                             ValidatorName = "",
                             ValidationDate = of.ValidationDate,
                             OfferStatus = os,
                             Status = of.Status,
                             CurrentUserId = of.CurrentUserId,
                             Created = of.Created,
                             Modified = of.Modified
                         };
            return result;

        }

        public async Task<IEnumerable<OfferInfoVM>> GetOperatorCompletedOffer()
        {
            var UserId = CurrentUserService.UserId.ToString();

            var result = from of in _dbContext.OfferInfos.Where(x => x.AcceptedOperatorId == UserId && (x.OfferStatusId == 5 || x.OfferStatusId == 2))
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId
                         join operatorObj in _dbContext.Users on of.AcceptedOperatorId equals operatorObj.Id.ToString()
                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = operatorObj.Name,
                             OfferStatusId = of.OfferStatusId,
                             OperatorAcceptedDate = of.OperatorAcceptedDate,
                             ValidatorId = of.ValidatorId,
                             ValidatorName = "",
                             ValidationDate = of.ValidationDate,
                             OfferStatus = os,
                             Status = of.Status,
                             CurrentUserId = of.CurrentUserId,
                             Created = of.Created,
                             Modified = of.Modified
                         };
            return result;

        }
        public async Task<IEnumerable<OfferInfoVM>> GetOperatorPendingOffer()
        {
            var UserId = CurrentUserService.UserId;
            var operatorDetails = await applicationUserService.GetByIdAsync(UserId);

            List<OfferInfoVM> newOffer = new List<OfferInfoVM>();

            var result = from of in _dbContext.OfferInfos.Where(x => (x.OfferStatusId == 1 || x.OfferStatusId == 3))
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId
                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             ProfBasicInfo=profile,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = "",
                             OfferStatusId = of.OfferStatusId,
                             OperatorAcceptedDate = of.OperatorAcceptedDate,
                             ValidatorId = of.ValidatorId,
                             ValidatorName = "",
                             ValidationDate = of.ValidationDate,
                             OfferStatus = os,
                             Status = of.Status,
                             CurrentUserId = of.CurrentUserId,
                             Created = of.Created,
                             Modified = of.Modified
                         };

            foreach (var offer in result)
            {
                if (offer.ProfBasicInfo.BranchInfoId != null && operatorDetails.OperatorBranches.Count > 0) {
                    if (operatorDetails.OperatorBranches.Where(x => x.BranchInfoId == (int)offer.ProfBasicInfo.BranchInfoId).ToList().Count > 0) {
                        offer.ProfBasicInfo = null;
                        newOffer.Add(offer);
                    }
                }
                //else if (operatorDetails.OperatorKeywordIds.Where(x=>x.) offer.JobInfo.Title.Contains()) { }

                else if (offer.ProfBasicInfo.BranchInfoId == null) {
                    offer.ProfBasicInfo = null;
                    newOffer.Add(offer);
                }
            }

            return newOffer;

        }


        public async Task<string> OperatorOfferAcceptRequest(int offerInfoId)
        {
            try
            {
                var UserId = CurrentUserService.UserId;

                var offer = await GetFirstOrDefaultAsync(x => x, x => x.OfferInfoId == offerInfoId);
                if (offer==null) {
                    throw new Exception("This offer is not available. Please try another one.");
                }

                if (offer.OfferStatusId == (int)EnumOfferStatus.NewOffer || offer.OfferStatusId == (int)EnumOfferStatus.Pending)
                {
                    offer.OfferStatusId = (int)EnumOfferStatus.Received;
                    offer.OperatorAcceptedDate = DateTime.Now;
                    offer.AcceptedOperatorId = UserId.ToString();
                    offer.ModifiedBy = UserId;
                    var offerUpdate = await AddOrUpdate(offer);
                    return "Request has been accepted successfully.";

                }
                else
                {

                    //var apiResult = new ApiResponse
                    //{
                    //    StatusCode = 200,
                    //    Status = "Success",
                    //    Message = message,
                    //    Data = data
                    //};
                    //return ObjectResult(apiResult);
                    //return new object { status = "ok" };
                    throw new Exception("The job request already accepted another operator. Please try another one.");
                    //return $"The job request already accepted another operator. Please try another one.";
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<string> OperatorAcceptedOfferRevertRequest(int offerInfoId)
        {
            try
            {
                var UserId = CurrentUserService.UserId;

                var offer = await GetFirstOrDefaultAsync(x => x, x => x.OfferInfoId == offerInfoId);
                if (offer == null)
                {
                    throw new Exception("This offer is not available. Please try another one.");
                }


                if (offer.AcceptedOperatorId == UserId.ToString())
                {
                    offer.OfferStatusId = (int)EnumOfferStatus.Pending;
                    //offer.OperatorAcceptedDate = DateTime.Now;
                    offer.AcceptedOperatorId = null;
                    offer.ModifiedBy = UserId;
                    var offerUpdate = await AddOrUpdate(offer);
                    return "This job is again open for all. Anyone can accept this request and proceed.";

                }
                else
                {
                    throw new Exception("The job revert request is not applicable. Please try another one.");
                }
            }
            catch (Exception)
            {

                throw new Exception("System may have some issues. Contact with admin.");
            }

        }

        public async Task<OfferInfo> OperatorChangeOfferStatusRequest(int profileId,int offerInfoId, string status)
        {
            try
            {
                var UserId = CurrentUserService.UserId;

                var offer = await GetFirstOrDefaultAsync(x => x, x => x.OfferInfoId == offerInfoId && x.ProfileId==profileId);
                if (offer == null)
                {
                    throw new Exception("This offer is not available. Please try another one.");
                }

                var offerStatusId = 0;
                if (status.Contains("Completed"))
                {
                    offerStatusId = (int)EnumOfferStatus.Completed;
                }
                else if(status.Contains("Submitted")) {
                    offerStatusId = (int)EnumOfferStatus.Submitted;
                }else if(status.Contains("Documents")) {
                    offerStatusId = (int)EnumOfferStatus.DocumentsRequired;
                };

                if (offer.AcceptedOperatorId == UserId.ToString())
                {
                    offer.OfferStatusId = offerStatusId;
                    offer.ModifiedBy = UserId;
                    var offerUpdate = await AddOrUpdate(offer);
                    return offerUpdate;

                }
                else
                {
                    throw new Exception("You have no permission to update the information.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("System may have some issues. Contact with admin.");
            }

        }

        #endregion Operator

        #region client
        public async Task<IEnumerable<OfferInfoVM>> GetClientProgressOffer()
        {
            var UserId = CurrentUserService.UserId.ToString();

            var result = from of in _dbContext.OfferInfos.Where(x => x.AcceptedOperatorId == UserId && (x.OfferStatusId == 3 || x.OfferStatusId == 4 || x.OfferStatusId == 6 || x.OfferStatusId == 7))
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId
                         join operatorObj in _dbContext.Users on of.AcceptedOperatorId equals operatorObj.Id.ToString()
                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = operatorObj.Name,
                             OfferStatusId = of.OfferStatusId,
                             OperatorAcceptedDate = of.OperatorAcceptedDate,
                             ValidatorId = of.ValidatorId,
                             ValidatorName = "",
                             ValidationDate = of.ValidationDate,
                             OfferStatus = os,
                             Status = of.Status,
                             CurrentUserId = of.CurrentUserId,
                             Created = of.Created,
                             Modified = of.Modified
                         };
            return result;

        }

        public async Task<IEnumerable<OfferInfoVM>> GetClientCompletedOffer()
        {
            var UserId = CurrentUserService.UserId.ToString();

            var result = from of in _dbContext.OfferInfos.Where(x => x.AcceptedOperatorId == UserId && (x.OfferStatusId == 5 || x.OfferStatusId == 2))
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId
                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = "",
                             OfferStatusId = of.OfferStatusId,
                             OperatorAcceptedDate = of.OperatorAcceptedDate,
                             ValidatorId = of.ValidatorId,
                             ValidatorName = "",
                             ValidationDate = of.ValidationDate,
                             OfferStatus = os,
                             Status = of.Status,
                             CurrentUserId = of.CurrentUserId,
                             Created = of.Created,
                             Modified = of.Modified
                         };
            return result;

        }

        #endregion client


        public async Task<OfferInfo> GetById(int offerInfoId)
        {
            var checkVal = await IsExistsAsync(x => x.OfferInfoId == offerInfoId);
            if (checkVal)
            {
                //OfferInfo result = await GetFirstOrDefaultAsync(x => x, x => x.OfferInfoId == offerInfoId, x => x.Include(y => y.JobSectionLink));
                OfferInfo result = await GetFirstOrDefaultAsync(x => x, x => x.OfferInfoId == offerInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<OfferInfo> AddOrUpdate(OfferInfo offerInfo)
        {
            try
            {
                offerInfo.Created = DateTime.Now;
                OfferInfo result;
                if (offerInfo.OfferInfoId > 0)
                {
                    result = await UpdateAsync(offerInfo);
                }
                else
                {
                    result = await AddAsync(offerInfo);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int offerInfoId)
        {
            var result = await DeleteAsync(x => x.OfferInfoId == offerInfoId);
            return result;
        }
        public  dynamic GetCurrentStatusById(int profileId)
        {
            var result = from of in _dbContext.OfferInfos
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             ProfileId = of.ProfileId,
                             OfferStatusId = of.OfferStatusId,
                             OfferStatusName = os.OfferStatusName,
                             Title = job.Title,
                             Description = job.Description,
                             Created = of.Created,
                             Modified= of.Modified
                         };
            return result; 
        }

        public async Task<IEnumerable<OfferInfoVM>> GetMyProgressOffer()
        {
            var UserId = CurrentUserService.UserId.ToString();

            var result = from of in _dbContext.OfferInfos.Where(x => x.AcceptedOperatorId == UserId)
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId
                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = "",
                             OfferStatusId = of.OfferStatusId,
                             OperatorAcceptedDate = of.OperatorAcceptedDate,
                             ValidatorId = of.ValidatorId,
                             ValidatorName = "",
                             ValidationDate = of.ValidationDate,
                             OfferStatus = os,
                             Status = of.Status,
                             CurrentUserId = of.CurrentUserId,
                             Created = of.Created,
                             Modified = of.Modified
                         };
            return result;

        }
    }
}
