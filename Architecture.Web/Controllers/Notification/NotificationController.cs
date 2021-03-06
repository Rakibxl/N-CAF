using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities.Notification;
using Architecture.Web.Controllers.Common;
using Architecture.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Architecture.Web.Controllers.Notification
{
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/notification")]

    public class NotificationController : BaseController
    {
        private IHubContext<NotificationHub> notificationHubContext;
        private readonly INotificationService notificationService;
        public NotificationController(IHubContext<NotificationHub> notificationHubContext, INotificationService notificationService)
        {
            this.notificationHubContext = notificationHubContext;
            this.notificationService = notificationService;
        }

      
        [HttpPost("CreateOrUpdate")]
        public async Task<IActionResult> CreateOrUpdate([FromBody] NotificationInfo model)
        {
            return await ModelValidation(async () =>
            {
                var result = await notificationService.AddOrUpdate(model);
               //await notificationHubContext.Clients.All.SendAsync(result.MessageFor.ToString(), result);
                return OkResult(result);
            });
        }

        [HttpGet("GetNotification/{notificationId}")]
        public async Task<IActionResult> GetById(int notificationId)
        {
            try
            {
                var result = await notificationService.GetById(notificationId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetByOfferId/{offerInfoId}")]
        public async Task<IActionResult> GetByOfferInfoId(int offerInfoId)
        {
            try
            {
                var result = await notificationService.GetByOfferInfoId(offerInfoId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("GetByApplicationByAppUserId/{applicationUserId}")]
        public async Task<IActionResult> GetByApplicationUserId(Guid? applicationUserId)
        {
            try
            {
                var result = await notificationService.GetByApplicationByAppUserId(applicationUserId);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

        [HttpGet("CurrentUserNotification/{pageNumber}/{pageSize}")]
        public async Task<IActionResult> GetCurrentUserNotification(int pageNumber, int pageSize)
        {
            try
            {
                var result = await notificationService.GetCurrentUserNotification(pageNumber, pageSize);
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }


        [HttpGet("SeenUserNotification")]
        public async Task<IActionResult> SeenUserNotification()
        {
            try
            {
                var result = await notificationService.SeenUserNotification();
                return OkResult(result);
            }
            catch (Exception ex)
            {
                return ExceptionResult(ex);
            }
        }

    }
}
