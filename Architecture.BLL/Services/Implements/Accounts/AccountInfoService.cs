using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Interfaces.Accounts;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities.Accounts;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements.Accounts
{
   public class AccountInfoService : Repository<AccountInfo>, IAccountInfoService
    {

        private readonly ICurrentUserService currentUserService;
        public AccountInfoService(ApplicationDbContext dbContext, ICurrentUserService currentUserService) : base(dbContext)
        {
            this.currentUserService = currentUserService;
        }

        public async Task<IEnumerable<AccountInfo>> GetAll()
        {
            IEnumerable<AccountInfo> result;
            result = await GetAsync(x => x,x=>x.RecordStatusId==(int)EnumRecordStatus.Active);
            return result;
        }


        public async Task<AccountInfo> GetById(int accountInfoId)
        {
            var checkVal = await IsExistsAsync(x => x.AccountInfoId == accountInfoId && x.RecordStatusId == (int)EnumRecordStatus.Active);
            if (checkVal)
            {
                AccountInfo result = await GetByIdAsync(accountInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not availalbe. Please contact with admin.");
            }
        }
         public async Task<string> SyncAccountInfo()
        {
            var returnResult = "";
            var applicationUserType = currentUserService.UserTypeId;
            if (applicationUserType==(int) EnumApplicationUserType.Client|| applicationUserType == (int)EnumApplicationUserType.Operator) {
                AccountInfo accountInfo = await GetFirstOrDefaultAsync(x => x, x => x.MasterId == currentUserService.UserId.ToString() && x.AppUserTypeId== applicationUserType);
                if (accountInfo == null)
                {
                    var newAccountInfo = await AddOrUpdate(new AccountInfo
                    {
                        AccountName = currentUserService.UserName.ToString(),
                        AppUserTypeId = applicationUserType,
                        MasterId = currentUserService.UserId.ToString(),                        
                    });
                }
                else if (accountInfo.RecordStatusId != (int)EnumRecordStatus.Active)
                {
                    returnResult = "Your account information is available but deactive now. Please contact with admin.";
                }
                else {
                    returnResult = "Your account information synchronized. Thanks for connecting with us.";
                }
            }
                return returnResult;           
        }
        
        
        public async Task<AccountInfo> AddOrUpdate(AccountInfo accountInfo)
        {
            try
            {
                AccountInfo result;
                if (accountInfo.AccountInfoId > 0)
                {
                    accountInfo.ModifiedBy = currentUserService.UserId;
                    accountInfo.Modified = DateTime.Now;
                    accountInfo.AccountNumber = $"NC-{new Guid().ToString().Substring(1,6)}";
                    result = await UpdateAsync(accountInfo);
                }
                else
                {
                    accountInfo.CreatedBy = currentUserService.UserId;
                    accountInfo.Created = DateTime.Now;
                    accountInfo.RecordStatusId = (int)EnumRecordStatus.Active;
                    result = await AddAsync(accountInfo);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> Delete(int accountInfoId)
        {
            AccountInfo result = await GetFirstOrDefaultAsync(x => x, x => x.AccountInfoId == accountInfoId && x.RecordStatusId == (int)EnumRecordStatus.Active);
            if (result == null)
            {
                return "Accounts infomration is not available. Please contact with admin.";
            }
            result.Modified = DateTime.Now;
            result.ModifiedBy = currentUserService.UserId;
            result.RecordStatusId = (int)EnumRecordStatus.Deleted;
            await UpdateAsync(result);
            return "Information deleted successfully.";
        }
    }
}
