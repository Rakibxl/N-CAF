using Architecture.BLL.Services.Interfaces;
using System;

namespace Architecture.Web.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
