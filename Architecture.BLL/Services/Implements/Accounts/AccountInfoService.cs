using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Interfaces.Accounts;
using Architecture.BLL.Services.Models;
using Architecture.Core.Common.Enums;
using Architecture.Core.Entities.Accounts;
using Architecture.Core.Entities.Notification;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements.Accounts
{
   public class AccountInfoService : Repository<AccountInfo>, IAccountInfoService
    {

        private readonly ICurrentUserService currentUserService;
        private readonly INotificationService notificationService;
        private readonly IBranchService branchService;
        private readonly IApplicationUserService _userService;
        public AccountInfoService(ApplicationDbContext dbContext, ICurrentUserService currentUserService, INotificationService notificationService, IBranchService branchService, IApplicationUserService userService) : base(dbContext)
        {
            this.currentUserService = currentUserService;
            this.notificationService = notificationService;
            this.branchService = branchService;
            this._userService = userService;
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

        public async Task<AccountInfoVM> GetCurrentUserAccountDetails()
        {
            var applicationUserType = currentUserService.UserTypeId;

            AccountInfo accountInfo = await this.GetCurrentUserAccountInfo();
            if (accountInfo==null) {
                await SyncAccountInfo();
                accountInfo = await this.GetCurrentUserAccountInfo();
            }

            var currentUserId = currentUserService.UserId.ToString();

            var transactionDetails = _dbContext.TransactionDetails.Include(x=>x.RecordStatus).Where(x => x.AccountInfoId == accountInfo.AccountInfoId && (x.RecordStatusId == (int)EnumRecordStatus.Approved || x.RecordStatusId == (int)EnumRecordStatus.WaitingforApproval))
                .GroupBy(x => new { x.RecordStatusId }).Select(g =>
                  new {
                      RecordStatusId = g.Key.RecordStatusId,
                      DebitAmount=g.Sum(d=>d.Debit),
                      CreditAmount=g.Sum(d=>d.Credit),
                      Amount= g.Sum(d => d.Debit)- g.Sum(d => d.Credit)
                  }
                );

            var balanceRecord = transactionDetails.FirstOrDefault(x => x.RecordStatusId == (int)EnumRecordStatus.Approved);
            var pendingRecord = transactionDetails.FirstOrDefault(x => x.RecordStatusId == (int)EnumRecordStatus.WaitingforApproval);

            var accountInfoDetaiils = new AccountInfoVM
            {
                AccountInfoId = accountInfo.AccountInfoId,
                AccountNumber = accountInfo.AccountNumber,
                AccountName = accountInfo.AccountName,
                MasterId = accountInfo.MasterId,
                AppUserTypeId = accountInfo.AppUserTypeId,
                AppUserType = accountInfo.AppUserType,
                BalanceAmount = balanceRecord==null?0: balanceRecord.Amount,
                ProgressAmount = pendingRecord==null?0: pendingRecord.Amount,
                Created = accountInfo.Created,
                CreatedBy = accountInfo.CreatedBy,
                Modified = accountInfo.Modified,
                ModifiedBy = accountInfo.ModifiedBy,
                RecordStatusId = accountInfo.RecordStatusId,
                RecordStatus = accountInfo.RecordStatus
            };

            return accountInfoDetaiils;


    }
        public async Task<string> SyncAccountInfo()
        {
            var returnResult = "";
            var applicationUserType = currentUserService.UserTypeId;
            if (applicationUserType == (int)EnumApplicationUserType.Client || applicationUserType == (int)EnumApplicationUserType.Operator)
            {
                AccountInfo accountInfo = await GetFirstOrDefaultAsync(x => x, x => x.MasterId == currentUserService.UserId.ToString() && x.AppUserTypeId == applicationUserType);
                if (accountInfo == null)
                {
                    var newAccountInfo = await AddOrUpdate(new AccountInfo
                    {
                        AccountName = currentUserService.UserName.ToString(),
                        AppUserTypeId = applicationUserType,
                        MasterId = currentUserService.UserId.ToString(),
                        NotifyUserId= currentUserService.UserId
                    });

                    returnResult = $"Your account information synchronized. Account Number {newAccountInfo.AccountNumber} and Name {newAccountInfo.AccountName} Thanks for connecting with us.";
                }
                else if (accountInfo.RecordStatusId != (int)EnumRecordStatus.Active)
                {
                    returnResult = "Your account information is available but deactive now. Please contact with admin.";
                }
                else
                {
                    accountInfo.AccountName = currentUserService.UserName.ToString();
                    accountInfo.NotifyUserId = currentUserService.UserId;

                    var newAccountInfo = await UpdateAsync(accountInfo);
                    returnResult = "Your account information synchronized. Thanks for connecting with us.";
                }
            }
            else if (applicationUserType == (int)EnumApplicationUserType.BranchUser)
            {
                var branchInfoId = currentUserService.BranchInfoId;
                if (branchInfoId == null) { returnResult = "Your branch information is not mapped currently. Please try again with proper branch information."; }
                AccountInfo accountInfo = await GetFirstOrDefaultAsync(x => x, x => x.MasterId == branchInfoId.ToString() && x.AppUserTypeId == applicationUserType);
                var branchAdminUser = await _userService.GetAdminUserAsync(Int32.Parse(branchInfoId));
                if (accountInfo == null)
                {
                    var branchInfo = await branchService.GetById(Int32.Parse(branchInfoId));
                    var newAccountInfo = await AddOrUpdate(new AccountInfo
                    {
                        AccountName = branchInfo.BranchLocation,
                        AppUserTypeId = applicationUserType,
                        MasterId = branchInfoId.ToString(),
                        NotifyUserId= branchAdminUser?.Id
                    });

                    returnResult = $"Your account information synchronized. Account Number {newAccountInfo.AccountNumber} and Name {newAccountInfo.AccountName}. Thanks for connecting with us.";
                }
                else if (accountInfo.RecordStatusId != (int)EnumRecordStatus.Active)
                {
                    returnResult = "Your account information is available but deactive now. Please contact with admin.";
                }
                else
                {
                    var branchInfo = await branchService.GetById(Int32.Parse(branchInfoId));
                    accountInfo.NotifyUserId = branchAdminUser?.Id;
                    accountInfo.AccountName = branchInfo.BranchLocation;
                    var newAccountInfo = await UpdateAsync(accountInfo);
                    returnResult = "Your account information synchronized. Thanks for connecting with us.";
                }

            }else if (applicationUserType == (int)EnumApplicationUserType.Admin)
            {
                
                AccountInfo accountInfo = await GetFirstOrDefaultAsync(x => x, x => x.AppUserTypeId == applicationUserType);
                if (accountInfo == null)
                {
                    var AdminUser = await _userService.GetAdminUserAsync(0, true);
                    var newAccountInfo = await AddOrUpdate(new AccountInfo
                    {
                        AccountName = "N-CAP",
                        AppUserTypeId = applicationUserType,
                        MasterId = "0afe6406-257c-4d54-12ea-08d8f6726a",
                        NotifyUserId= AdminUser.Id

                    });
                }
                else if (accountInfo.RecordStatusId != (int)EnumRecordStatus.Active)
                {
                    returnResult = "Your account information is available but deactive now. Please contact with admin.";
                }
                else
                {
                    var AdminUser = await _userService.GetAdminUserAsync(0, true);
                    accountInfo.NotifyUserId = AdminUser.Id;

                    var newAccountInfo = await UpdateAsync(accountInfo);
                    returnResult = "Your account information synchronized. Thanks for connecting with us.";
                }

            }

            return returnResult;           
        }

        public async Task<AccountInfo> GetCurrentUserAccountInfo() {
            var applicationUserType = currentUserService.UserTypeId;
            AccountInfo accountInfo = new AccountInfo();
            if (applicationUserType == (int)EnumApplicationUserType.Client || applicationUserType == (int)EnumApplicationUserType.Operator)
            {
                accountInfo = await GetFirstOrDefaultAsync(x => x, x => x.MasterId == currentUserService.UserId.ToString() && x.AppUserTypeId == applicationUserType);
            }
            else if (applicationUserType == (int)EnumApplicationUserType.BranchUser)
            {
                var branchInfoId = currentUserService.BranchInfoId;
                 accountInfo = await GetFirstOrDefaultAsync(x => x, x => x.MasterId == branchInfoId.ToString() && x.AppUserTypeId == applicationUserType);
            }
            else if (applicationUserType == (int)EnumApplicationUserType.Admin)
            {
                 accountInfo = await GetFirstOrDefaultAsync(x => x, x => x.AppUserTypeId == applicationUserType);                
            }
            return accountInfo;
        }

        public async Task<AccountInfo> GetAccountInfoByUserId(Guid? userId)
        {
            var userInfo =await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var applicationUserType = userInfo.AppUserTypeId;
            AccountInfo accountInfo = new AccountInfo();
            if (applicationUserType == (int)EnumApplicationUserType.Client || applicationUserType == (int)EnumApplicationUserType.Operator)
            {
                accountInfo = await GetFirstOrDefaultAsync(x => x, x => x.MasterId == userInfo.Id.ToString() && x.AppUserTypeId == applicationUserType);
            }
            else if (applicationUserType == (int)EnumApplicationUserType.BranchUser)
            {
                var branchInfoId = userInfo.BranchInfoId;
                accountInfo = await GetFirstOrDefaultAsync(x => x, x => x.MasterId == branchInfoId.ToString() && x.AppUserTypeId == applicationUserType);
            }
            else if (applicationUserType == (int)EnumApplicationUserType.Admin)
            {
                accountInfo = await GetFirstOrDefaultAsync(x => x, x => x.AppUserTypeId == applicationUserType);
            }
            return accountInfo;
        }
        public async Task<AccountInfo> AddOrUpdate(AccountInfo accountInfo)
        {
            try
            {
                AccountInfo result;
                if (accountInfo.AccountInfoId > 0)
                {
                    accountInfo.ModifiedBy = currentUserService.UserId;
                    accountInfo.Modified = DateTime.UtcNow;
                    result = await UpdateAsync(accountInfo);

                    await this.notificationService.AddOrUpdate(new NotificationInfo
                    {
                        MessageContent = $"Your account has been synchronized successfully at {(DateTime.UtcNow.ToString("dd/mm/yyyy hh:mm:ss tt"))}. \n" +
                       $"<b> A/C Number:  {result.AccountNumber}</b>\n <b> A/C Name:  {result.AccountName}</b>",
                        MessageFor = result.CreatedBy
                    });
                }
                else
                {
                    accountInfo.CreatedBy = currentUserService.UserId;
                    accountInfo.Created = DateTime.UtcNow;
                    accountInfo.RecordStatusId = (int)EnumRecordStatus.Active;
                    accountInfo.AccountNumber = $"NC-{Guid.NewGuid().ToString().Substring(1, 6)}";
                    result = await AddAsync(accountInfo);

                    await this.notificationService.AddOrUpdate(new NotificationInfo { 
                        MessageContent=$"Your account has been synchronized successfully at {(DateTime.UtcNow.ToString("dd/mm/yyyy hh:mm:ss tt"))}. \n" +
                        $"<b> A/C Number:  {result.AccountNumber}</b>\n <b> A/C Name:  {result.AccountName}</b>",
                        MessageFor= result.CreatedBy
                    });
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
            result.Modified = DateTime.UtcNow;
            result.ModifiedBy = currentUserService.UserId;
            result.RecordStatusId = (int)EnumRecordStatus.Deleted;
            await UpdateAsync(result);
            return "Information deleted successfully.";
        }
    }
}
