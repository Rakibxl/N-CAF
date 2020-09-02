using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces
{
    public interface IDashboardService : IDisposable
    {
        Task<object> GetDashboardDataAsync();
    }
}
