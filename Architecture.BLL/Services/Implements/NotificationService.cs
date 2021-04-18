using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities.Notification;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Notification
{
    public class NotificationService : Repository<NotificationInfo>, INotificationService
    {

        private readonly ICurrentUserService currentUserService;
        //private IHubContext<NotificationHub> notificationHubContext;
        public NotificationService(ApplicationDbContext dbContext, ICurrentUserService currentUserService) : base(dbContext)
        {
            this.currentUserService = currentUserService;
        }

        public async Task<IEnumerable<NotificationInfo>> GetAll()
        {
            IEnumerable<NotificationInfo> result;
            result = await GetAsync(x => x);
            return result;
        }


        public async Task<NotificationInfo> GetById(int notificationId)
        {
            var checkVal = await IsExistsAsync(x => x.NotificationInfoId == notificationId);
            if (checkVal)
            {
                NotificationInfo result = await GetByIdAsync(notificationId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }
        public async Task<List<NotificationInfo>> GetByOfferInfoId(int offerInfoId)
        {
            var checkVal = await IsExistsAsync(x => x.OfferInfoId == offerInfoId);
            if (checkVal)
            {
                var result = await GetAsync(x=>x,x=>x.OfferInfoId==offerInfoId);
                return result.ToList();
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }
        public async Task<List<NotificationInfo>> GetCurrentUserNotification(int pageNumber, int pageSize)
        {
            IEnumerable<NotificationInfo> allSection;
            var currentUserId = currentUserService.UserId;
            allSection = await GetAsync(x => x, x=>x.MessageFor==currentUserId, x=>x.OrderBy(x=>x.Created));           
            return allSection.ToList();
        }

        public async Task<NotificationInfo> AddOrUpdate(NotificationInfo notification)
        {
            try
            {
                NotificationInfo result;
                if (notification.NotificationInfoId > 0)
                {
                    notification.CreatedBy = currentUserService.UserId;
                    result = await UpdateAsync(notification);
                }
                else
                {
                    result = await AddAsync(notification);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int notificationId)
        {
            var result = await DeleteAsync(x => x.NotificationInfoId == notificationId);
            return result;
        }
    }
}
