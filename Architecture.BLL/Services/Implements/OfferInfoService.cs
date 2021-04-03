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

namespace Architecture.BLL.Services.Implements
{
    public class OfferInfoService: Repository<OfferInfo>, IOfferInfoService
    {
        private readonly IJobInformationService jobInformationService;
        private readonly ICurrentUserService CurrentUserService;
        public OfferInfoService(ApplicationDbContext dbContext, IJobInformationService jobInformationService, ICurrentUserService CurrentUserService
            ) : base(dbContext)
        {
            this.jobInformationService = jobInformationService;
            this.CurrentUserService = CurrentUserService;
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

        public async Task<IEnumerable<OfferInfoVM>> GetOperatorCompletedOffer()
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
        public async Task<IEnumerable<OfferInfoVM>> GetOperatorPendingOffer()
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

        #endregion Operator

        #region client
        public async Task<IEnumerable<OfferInfoVM>> GetClientProgressOffer()
        {
            var UserId = CurrentUserService.UserId.ToString();

            var result = from of in _dbContext.OfferInfos.Where(x => x.AcceptedOperatorId == UserId && (x.OfferStatusId == 3 || x.OfferStatusId == 4 || x.OfferStatusId == 6 || x.OfferStatusId == 7))
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
