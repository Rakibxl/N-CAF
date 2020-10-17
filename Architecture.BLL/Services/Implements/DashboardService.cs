using Architecture.Core.Common.Constants;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Interfaces;
using Architecture.BLL.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements
{
    public class DashboardService : IDashboardService
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IDateTime _dateTimeService;

        public DashboardService(IApplicationUserService applicationUserService,
            IDateTime dateTimeService)
        {
            this._applicationUserService = applicationUserService;
            this._dateTimeService = dateTimeService;
        }

        public async Task<object> GetDashboardDataAsync()
        {
            var currentDate = _dateTimeService.Now;

            #region Tiles
            // Service Request Current Day
            var fromDate = currentDate;
            var toDate = currentDate;

            var serviceRequestCurrentDay = await this.GetServiceRequisitionCountAsync(fromDate, toDate);

            // Service Request Current Week
            DayOfWeek currentDay = currentDate.DayOfWeek;  
            int daysTillCurrentDay = currentDay - DayOfWeek.Sunday;
            fromDate = currentDate.AddDays(-daysTillCurrentDay);
            toDate = currentDate;

            var serviceRequestCurrentWeek = await this.GetServiceRequisitionCountAsync(fromDate, toDate);

            // Service Request Current Month
            fromDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            toDate = currentDate;

            var serviceRequestCurrentMonth = await this.GetServiceRequisitionCountAsync(fromDate, toDate);

            // New AppUser Register Current Month
            fromDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            toDate = currentDate;

            var newAppUserRegisterCurrentMonth = await this.GetNewAppRegisterUserCountAsync(fromDate, toDate);
            #endregion

            #region Charts
            // Service Request Charts
            fromDate = currentDate.AddDays(-30);
            toDate = currentDate;

            var serviceRequestCharts = (await this.GetServiceRequisitionCountWithDateAsync(fromDate, toDate))
                                                    .Select(x => new { x.DateTime, DateTimeText = x.DateTime.ToString("dd-MM-yyyy"), x.TotalServiceRequisition }).ToList();
            var chkDate = fromDate;
            while (chkDate <= toDate)
            {
                if (!serviceRequestCharts.Any(x => x.DateTime.Date == chkDate.Date))
                    serviceRequestCharts.Add(new { DateTime = chkDate, DateTimeText = chkDate.ToString("dd-MM-yyyy"), TotalServiceRequisition = 0 });

                chkDate = chkDate.AddDays(1);
            }
            serviceRequestCharts = serviceRequestCharts.OrderBy(x => x.DateTime).ToList();

            // New AppUser Register Charts
            fromDate = currentDate.AddDays(-30);
            toDate = currentDate;

            var newAppUserRegisterCharts = (await this.GetNewAppRegisterUserCountWithDateAsync(fromDate, toDate))
                                                    .Select(x => new { x.DateTime, DateTimeText = x.DateTime.ToString("dd-MM-yyyy"), x.TotalAppRegisterUser }).ToList();
            chkDate = fromDate;
            while (chkDate <= toDate)
            {
                if (!newAppUserRegisterCharts.Any(x => x.DateTime.Date == chkDate.Date))
                    newAppUserRegisterCharts.Add(new { DateTime = chkDate, DateTimeText = chkDate.ToString("dd-MM-yyyy"), TotalAppRegisterUser = 0 });

                chkDate = chkDate.AddDays(1);
            }
            newAppUserRegisterCharts = newAppUserRegisterCharts.OrderBy(x => x.DateTime).ToList();
            #endregion

            #region Tables
            var topAppUsers = await this.GetTopAppUserByPointsAsync(5);
            #endregion

            var result = new
            {
                ServiceRequestCurrentDay = serviceRequestCurrentDay,
                ServiceRequestCurrentWeek = serviceRequestCurrentWeek,
                ServiceRequestCurrentMonth = serviceRequestCurrentMonth,
                NewAppUserRegisterCurrentMonth = newAppUserRegisterCurrentMonth,
                ServiceRequestCharts = serviceRequestCharts,
                NewAppUserRegisterCharts = newAppUserRegisterCharts,
                TopAppUsers = topAppUsers
            };

            return result;
        }

        private async Task<IList<(DateTime DateTime, int TotalAppRegisterUser)>> GetNewAppRegisterUserCountWithDateAsync(DateTime fromDate, DateTime toDate)
        {
            var result = (await _applicationUserService.GetAsync(x => new { x.Created }, x => !x.IsLocked && 
                                                            x.UserRoles.Any(ur => ur.Role.Name == ConstantsValue.UserRoleName.AppUser) &&
                                                            x.Created.Date >= fromDate.Date && x.Created.Date <= toDate.Date,
                                                            x => x.OrderBy(o => o.Created), 
                                                            null, 
                                                            true))
                                                            .GroupBy(x => x.Created.Date).Select(x => (DateTime: x.Key, TotalAppRegisterUser: x.Count())).ToList();
            return result;
        }

        private async Task<int> GetNewAppRegisterUserCountAsync(DateTime fromDate, DateTime toDate)
        {
            var result = (await _applicationUserService.GetAsync(x => x, x => !x.IsLocked &&
                                                            x.UserRoles.Any(ur => ur.Role.Name == ConstantsValue.UserRoleName.AppUser) &&
                                                            x.Created.Date >= fromDate.Date && x.Created.Date <= toDate.Date,
                                                            null, null, true)).Count();
            return result;
        }

        private async Task<IList<(DateTime DateTime, int TotalServiceRequisition)>> GetServiceRequisitionCountWithDateAsync(DateTime fromDate, DateTime toDate)
        {
            var result = new List<(DateTime DateTime, int TotalServiceRequisition)>();
            return result;
        }

        private async Task<int> GetServiceRequisitionCountAsync(DateTime fromDate, DateTime toDate)
        {
            var result = 0;
            return result;
        }

        private async Task<object> GetTopAppUserByPointsAsync(int take)
        {
            var result = new List<object>() { new { FullName = "", Email = "", PhoneNumber = "", Points = 0 } };
            return result;
        }

        public void Dispose()
        {
            return;
        }
    }
}
