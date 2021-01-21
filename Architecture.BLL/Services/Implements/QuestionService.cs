using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using Architecture.Core.Entities;
using Architecture.Core.Entities.NotMapped;
using Architecture.Core.Common.Enums;
using Architecture.Core.Repository.Extensions;
using Architecture.BLL.Services.Exceptions;
using Architecture.Core.Common.Constants;
using System.Transactions;
using Microsoft.EntityFrameworkCore.Query;
using Architecture.Core.Common.Helpers;
using System.IO;
using iTextSharp.text.pdf;
using Architecture.Core.Repository.Interfaces;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Context;
using Architecture.BLL.Services.Interfaces;
using Architecture.BLL.Services.Interfaces.ClientProfile;

namespace Architecture.BLL.Services.Implements
{

    public class QuestionService : Repository<QuestionInfo>, IQuestionService
    {

        private readonly IBasicInfoService basicInfoService;
        private readonly ICurrentUserService currentUserService;

        public QuestionService(ApplicationDbContext dbContext, IBasicInfoService basicInfoService, ICurrentUserService _currentUserService) : base(dbContext)
        {
            this.basicInfoService = basicInfoService;
            this.currentUserService = _currentUserService;
        }

        public async Task<IEnumerable<QuestionInfo>> GetAll()
        {
            IEnumerable<QuestionInfo> result;
            result = await GetAsync(x => x, null, null, x=> x.Include(y=> y.SectionName));
            return result;
        }

        public async Task<IEnumerable<QuestionInfo>> GetUserQuestion()
        {

            ProfBasicInfo profileSections = await basicInfoService.GetBasicWithIncludeAll();

            IEnumerable<QuestionInfo> result = await GetAsync(x => x, null, null, x => x.Include(y => y.SectionName)); 

            if (profileSections == null && currentUserService.UserTypeId==1)
            {
                foreach (var item in result)
                {
                    item.SectionNameId = 0;
                }
                    return result;
            }else if (profileSections == null)
            {
                return new List<QuestionInfo>();
            }

            

            foreach (var item in result)
            {
                item.SectionNameId = profileSections.ProfileId;
                switch (item.SectionName.SectionDescription)
                {

                    case "Basic Info":
                        item.Status = profileSections.ProfileId != 0 ? "Active" : "InActive";
                        break;
                    case "Occupation Info":
                        item.Status = profileSections.ProfOccupationInfos != null && profileSections.ProfOccupationInfos.Any() ? "Active" : "InActive";
                        break;
                    case "Family Info":
                        item.Status = profileSections.ProfFamilyInfos != null && profileSections.ProfFamilyInfos.Any() ? "Active" : "InActive";
                        break;
                    case "Education Info":
                        item.Status = profileSections.ProfEducationInfos != null && profileSections.ProfEducationInfos.Any() ? "Active" : "InActive";
                        break;
                    case "Address Info":
                        item.Status = profileSections.ProfAddressInfos != null && profileSections.ProfAddressInfos.Any() ? "Active" : "InActive";
                        break;
                    case "House Rent Info":
                        item.Status = profileSections.ProfHouseRentInfos != null && profileSections.ProfHouseRentInfos.Any() ? "Active" : "InActive";
                        break;
                    case "Document Info":
                        item.Status = profileSections.ProfDocumentInfos != null && profileSections.ProfDocumentInfos.Any() ? "Active" : "InActive";
                        break;
                    case "Income Info":
                        item.Status = profileSections.ProfIncomeInfos != null && profileSections.ProfIncomeInfos.Any() ? "Active" : "InActive";
                        break;
                    default:
                        break;
                }

            }
            return result;
        }

        public async Task<QuestionInfo> GetById(int questionInfoId)
        {
            var checkVal = await IsExistsAsync(x => x.QuestionInfoId == questionInfoId);
            if (checkVal)
            {
                QuestionInfo result = await GetByIdAsync(questionInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<QuestionInfo> AddOrUpdate(QuestionInfo questionInfo)
        {
            try
            {
                QuestionInfo result;
                if (questionInfo.QuestionInfoId > 0)
                {
                    result = await UpdateAsync(questionInfo);
                }
                else
                {
                    result = await AddAsync(questionInfo);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int questionInfoId)
        {
            var result = await DeleteAsync(x => x.QuestionInfoId == questionInfoId);
            return result;
        }
    }
}
