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
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Microsoft.AspNetCore.SignalR;
using Architecture.Web.Hubs;

namespace Architecture.BLL.Services.Implements
{
    public class OfferInfoService: Repository<OfferInfo>, IOfferInfoService
    {
        private readonly IJobInformationService jobInformationService;
        private readonly ICurrentUserService CurrentUserService;
        private readonly IApplicationUserService applicationUserService;
        private readonly IBasicInfoService basicInfoService;
        private IHubContext<NotificationHub> notificationHubContext;
        public OfferInfoService(ApplicationDbContext dbContext, IJobInformationService jobInformationService, ICurrentUserService CurrentUserService,
           IApplicationUserService applicationUserService, IBasicInfoService basicInfoService, IHubContext<NotificationHub> notificationHubContext) : base(dbContext)
        {
            this.jobInformationService = jobInformationService;
            this.CurrentUserService = CurrentUserService;
            this.applicationUserService = applicationUserService;
            this.basicInfoService = basicInfoService;
            this.notificationHubContext = notificationHubContext;
        }

        #region Operator
        public async Task<IEnumerable<OfferInfoVM>> GetOperatorProgressOffer()
        {
            var UserId = CurrentUserService.UserId.ToString();
            var result = from of in _dbContext.OfferInfos.Where(x => x.AcceptedOperatorId == UserId && (x.OfferStatusId == (int)EnumOfferStatus.Received || x.OfferStatusId == (int)EnumOfferStatus.DocumentsRequired || x.OfferStatusId == (int)EnumOfferStatus.InformationRequired))
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId

                         join op in _dbContext.Users on of.AcceptedOperatorId equals op.Id.ToString() into opObj
                         from operatorObj in opObj.DefaultIfEmpty()

                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             Code = of.Code,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = $"{operatorObj.Name} {operatorObj.SurName}",
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

            var result = from of in _dbContext.OfferInfos.Where(x => x.AcceptedOperatorId == UserId && (x.OfferStatusId == (int)EnumOfferStatus.Completed))
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId

                         join op in _dbContext.Users on of.AcceptedOperatorId equals op.Id.ToString() into opObj
                         from operatorObj in opObj.DefaultIfEmpty()

                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             Code = of.Code,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = $"{operatorObj.Name} {operatorObj.SurName}",
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
                    offer.CurrentUserId = UserId;
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
                    offer.CurrentUserId = null;
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
        public async Task<IEnumerable<JobInfo>> GetMyOffer(int profileId)
        {
            var result = await jobInformationService.GetAll();
            return result;
        }
        public async Task<IEnumerable<OfferInfoVM>> GetClientProgressOffer(int profileId)
        {
            var UserId = CurrentUserService.UserId.ToString();
            var userType = CurrentUserService.UserTypeId;
            if (profileId==0 && userType==(int)EnumAppUserType.Client) {
              var profileInfo =await basicInfoService.GetCurrentUserBasicInfo();
                profileId = profileInfo.ProfileId;
            }

            var result = from of in _dbContext.OfferInfos.Where(x => x.ProfileId == profileId && (x.OfferStatusId == (int)EnumOfferStatus.Pending || x.OfferStatusId == (int)EnumOfferStatus.NewOffer || x.OfferStatusId == (int)EnumOfferStatus.Submitted || x.OfferStatusId == (int)EnumOfferStatus.Received || x.OfferStatusId == (int)EnumOfferStatus.DocumentsRequired || x.OfferStatusId == (int)EnumOfferStatus.InformationRequired))
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId

                         join op in _dbContext.Users on of.AcceptedOperatorId equals op.Id.ToString() into opObj
                         from operatorObj in opObj.DefaultIfEmpty()

                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             Code = of.Code,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = $"{operatorObj.Name} {operatorObj.SurName}",
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

        public async Task<IEnumerable<OfferInfoVM>> GetClientCompletedOffer(int profileId)
        {
            var UserId = CurrentUserService.UserId.ToString();
            var userType = CurrentUserService.UserTypeId;
            if (profileId == 0 && userType == (int)EnumAppUserType.Client)
            {
                var profileInfo = await basicInfoService.GetCurrentUserBasicInfo();
                profileId = profileInfo.ProfileId;
            }

            var result = from of in _dbContext.OfferInfos.Where(x => x.ProfileId == profileId && (x.OfferStatusId == (int)EnumOfferStatus.Completed))
                         join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                         join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId

                         join op in _dbContext.Users on of.AcceptedOperatorId equals op.Id.ToString() into opObj
                         from operatorObj in opObj.DefaultIfEmpty()

                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             Code = of.Code,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = $"{operatorObj.Name} {operatorObj.SurName}",
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
                OfferInfo result;
                if (offerInfo.OfferInfoId > 0)
                {
                    offerInfo.Modified = DateTime.Now;
                    offerInfo.ModifiedBy = CurrentUserService.UserId;
                    result = await UpdateAsync(offerInfo);
                }
                else
                {
                    offerInfo.Created = DateTime.Now;
                    offerInfo.CreatedBy = CurrentUserService.UserId;
                    offerInfo.CurrentUserId = CurrentUserService.UserId;
                    offerInfo.RecordStatusId = (int)EnumRecordStatus.Active;
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

                         join op in _dbContext.Users on of.AcceptedOperatorId equals op.Id.ToString() into opObj
                         from operatorObj in opObj.DefaultIfEmpty()

                         join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                         select new OfferInfoVM()
                         {
                             OfferInfoId = of.OfferInfoId,
                             JobId = of.JobId,
                             JobInfo = job,
                             ProfileId = of.ProfileId,
                             ProfileName = profile.Name,
                             AcceptedOperatorId = of.AcceptedOperatorId,
                             AcceptedOperatorName = $"{operatorObj.Name} {operatorObj.SurName}",
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
        
        public async Task<IEnumerable<OfferInfoVM>> GetProgressOfferForChatting()
        {
            var UserId = CurrentUserService.UserId.ToString();
            var userType=(int) CurrentUserService.UserTypeId;
            IEnumerable<OfferInfoVM> result = new List<OfferInfoVM>();

            if (userType==(int)EnumApplicationUserType.Operator) { // operator chatting
                 result = from of in _dbContext.OfferInfos.Where(x => x.AcceptedOperatorId == UserId && (x.OfferStatusId == (int)EnumOfferStatus.Received || x.OfferStatusId == (int)EnumOfferStatus.Pending || x.OfferStatusId == (int)EnumOfferStatus.DocumentsRequired || x.OfferStatusId == (int)EnumOfferStatus.InformationRequired))
                             join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId
                             join profile in _dbContext.ProfBasicInfos on of.ProfileId equals profile.ProfileId

                             join op in _dbContext.Users on of.AcceptedOperatorId equals op.Id.ToString() into opObj
                             from operatorObj in opObj.DefaultIfEmpty()

                             //join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                             select new OfferInfoVM()
                             {
                                 OfferInfoId = of.OfferInfoId,
                                 JobId = of.JobId,
                                 Code=of.Code,
                                // JobInfo = job,
                                 ProfileId = of.ProfileId,
                                 ProfileName = profile.Name,
                                 AcceptedOperatorId = of.AcceptedOperatorId,
                                 //AcceptedOperatorName = $"{operatorObj.Name} {operatorObj.SurName}",
                                 //OfferStatusId = of.OfferStatusId,
                                 //OperatorAcceptedDate = of.OperatorAcceptedDate,
                                 //ValidatorId = of.ValidatorId,
                                 //ValidatorName = "",
                                 //ValidationDate = of.ValidationDate,
                                 OfferStatus = os,
                                 //Status = of.Status,
                                 CurrentUserId = of.CurrentUserId,
                                 CreatedBy = of.CreatedBy,
                                 //Created = of.Created,
                                 //Modified = of.Modified
                             };
                return result;

            }
            else if (userType == (int)EnumApplicationUserType.Client)// client chatting
            {
                result =await GetClientProgressOffer(0);

            }
            else if (userType == (int)EnumApplicationUserType.Admin|| userType == (int)EnumApplicationUserType.BranchUser) // operator chatting
            {
                int branchInfoId =Int32.Parse (CurrentUserService.BranchInfoId.ToString()); 
                 result = from of in _dbContext.OfferInfos.Where(x => (x.OfferStatusId == (int)EnumOfferStatus.Pending || x.OfferStatusId == (int)EnumOfferStatus.NewOffer || x.OfferStatusId == (int)EnumOfferStatus.Submitted || x.OfferStatusId == (int)EnumOfferStatus.Received || x.OfferStatusId == (int)EnumOfferStatus.DocumentsRequired || x.OfferStatusId == (int)EnumOfferStatus.InformationRequired))
                             join os in _dbContext.OfferStatus on of.OfferStatusId equals os.OfferStatusId 
                             join profile in _dbContext.ProfBasicInfos.Where(x=>x.BranchInfoId==branchInfoId) on of.ProfileId equals profile.ProfileId 

                          join op in _dbContext.Users on of.AcceptedOperatorId equals op.Id.ToString() into opObj
                             from operatorObj in opObj.DefaultIfEmpty()

                             join job in _dbContext.JobInfos on of.JobId equals job.JobInfoId
                             select new OfferInfoVM()
                             {
                                 OfferInfoId = of.OfferInfoId,
                                 JobId = of.JobId,
                                 Code = of.Code,
                                 JobInfo = job,
                                 ProfileId = of.ProfileId,
                                 ProfileName = profile.Name,
                                 AcceptedOperatorId = of.AcceptedOperatorId,
                                 //AcceptedOperatorName = $"{operatorObj.Name} {operatorObj.SurName}",
                                 //OfferStatusId = of.OfferStatusId,
                                 //OperatorAcceptedDate = of.OperatorAcceptedDate,
                                 //ValidatorId = of.ValidatorId,
                                 //ValidatorName = "",
                                 //ValidationDate = of.ValidationDate,
                                 OfferStatus = os,
                                 Status = of.Status,
                                 CurrentUserId = of.CurrentUserId,
                                 CreatedBy = of.CreatedBy,
                                 //Created = of.Created,
                                 //Modified = of.Modified
                             };
                return result.ToList();

            }
            return result;

        }
    }
}
