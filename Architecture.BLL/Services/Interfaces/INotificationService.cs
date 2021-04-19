using Architecture.Core.Entities.Notification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
   public interface INotificationService
    {
        Task<IEnumerable<NotificationInfo>> GetAll();
        Task<NotificationInfo> GetById(int notificationId);
        Task<List<NotificationInfo>> GetCurrentUserNotification(int pageNumber, int pageSize);
        Task<NotificationInfo> AddOrUpdate(NotificationInfo notification);
        Task<int> Delete(int notificationId);
        Task<List<NotificationInfo>> GetByOfferInfoId(int offerInfoId);
        Task<List<NotificationInfo>> GetByApplicationByAppUserId(Guid? applicationUserId);

    }
}
