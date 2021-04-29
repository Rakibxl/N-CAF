using Architecture.BLL.Services.Models;
using Architecture.Core.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.Accounts
{
   public interface IAccountInfoService
    {
       Task<IEnumerable<AccountInfo>> GetAll();
        Task<AccountInfo> GetById(int accountInfoId);
        Task<AccountInfo> AddOrUpdate(AccountInfo accountInfo);
        Task<string> SyncAccountInfo();
        Task<string> Delete(int accountInfoId);
        Task<AccountInfoVM> GetCurrentUserAccountDetails();
        Task<AccountInfo> GetCurrentUserAccountInfo();
        Task<AccountInfo> GetAccountInfoByUserId(Guid? userId);
    }
}
