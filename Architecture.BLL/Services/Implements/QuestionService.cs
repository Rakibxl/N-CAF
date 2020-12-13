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

namespace Architecture.BLL.Services.Implements
{

    public class QuestionService : Repository<QuestionInfo>, IQuestionService
    {
        public QuestionService(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<QuestionInfo>> GetAll()
        {
            IEnumerable<QuestionInfo> result;
            result = await GetAsync(x => x);
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
