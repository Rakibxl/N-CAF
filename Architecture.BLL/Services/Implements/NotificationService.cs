using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities.Notification;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Architecture.Web.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Notification
{
    public class NotificationService : Repository<NotificationInfo>, INotificationService
    {

        private readonly ICurrentUserService currentUserService;
        private IHubContext<NotificationHub> notificationHubContext;
        public NotificationService(ApplicationDbContext dbContext, ICurrentUserService currentUserService, IHubContext<NotificationHub> notificationHubContext) : base(dbContext)
        {
            this.currentUserService = currentUserService;
            this.notificationHubContext = notificationHubContext;
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
                var result = await GetAsync(x=>x,x=>x.OfferInfoId==offerInfoId);

            //var parameter = Expression.Parameter(typeof());
            //Expression predicate = Expression.Constant(true);
            //Expression property = Expression.Property(parameter, nameOfParameter);
            //Expression equal = Expression.Equal(property, Expression.Constant(valueToCompare));
            //predicate = Expression.AndAlso(predicate, equal);

            return result.ToList();           
        }
        public async Task<List<NotificationInfo>> GetCurrentUserNotification(int pageNumber, int pageSize)
        {
            IEnumerable<NotificationInfo> allSection;
            var currentUserId = currentUserService.UserId;
            allSection = await GetAsync(x => x, x=>x.MessageFor==currentUserId, x=>x.OrderByDescending(x=>x.Created));           
            return allSection.ToList();
        }
         public async Task<List<NotificationInfo>> GetByApplicationByAppUserId(Guid? applicationUserId)
        {
            IEnumerable<NotificationInfo> allSection;
            var currentUserId = currentUserService.UserId;
            allSection = await GetAsync(x => x, x=>(x.MessageFor== applicationUserId && x.CreatedBy== currentUserId) || (x.MessageFor == currentUserId && x.CreatedBy == applicationUserId), x=>x.OrderByDescending(x=>x.Created));           
            return allSection.ToList();
        }

        public async Task<NotificationInfo> AddOrUpdate(NotificationInfo notification)
        {
            try
            {
                NotificationInfo result;
                if (notification.NotificationInfoId > 0)
                {
                    notification.ModifiedBy = currentUserService.UserId;
                    notification.Modified = DateTime.Now;
                    result = await UpdateAsync(notification);
                }
                else
                {
                    notification.CreatedBy = currentUserService.UserId;
                    notification.Created = DateTime.Now;
                    notification.RecordStatusId = (int)EnumRecordStatus.Active;
                    result = await AddAsync(notification);
                }
                await notificationHubContext.Clients.All.SendAsync(result.MessageFor.ToString(), result);
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
