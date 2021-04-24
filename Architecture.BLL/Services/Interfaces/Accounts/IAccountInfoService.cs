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
        Task<string> Delete(int accountInfoId);
    }
}
