﻿using Architecture.BLL.Services.Interfaces;
using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements
{
    public class OfferInfoService: Repository<OfferInfo>, IOfferInfoService
    {
        private readonly IJobInformationService jobInformationService;
        public OfferInfoService(ApplicationDbContext dbContext, IJobInformationService jobInformationService) : base(dbContext)
        {
            this.jobInformationService = jobInformationService;
        }

        public async Task<IEnumerable<JobInfo>> GetMyOffer()
        {
            var result = await jobInformationService.GetAll();
            return result;
        }

        public async Task<OfferInfo> GetById(int offerInfoId)
        {
            var checkVal = await IsExistsAsync(x => x.OfferInfoId == offerInfoId);
            if (checkVal)
            {
                //OfferInfo result = await GetFirstOrDefaultAsync(x => x, x => x.OfferInfoId == offerInfoId, x => x.Include(y => y.JobSectionLink));
                OfferInfo result = await GetFirstOrDefaultAsync(x => x, x => x.OfferInfoId == offerInfoId);
                return result;
            }
            else
            {
                throw new Exception("Information is not exists.");
            }
        }

        public async Task<OfferInfo> AddOrUpdate(OfferInfo offerInfo)
        {
            try
            {
                OfferInfo result;
                if (offerInfo.OfferInfoId > 0)
                {
                    result = await UpdateAsync(offerInfo);
                }
                else
                {
                    result = await AddAsync(offerInfo);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Delete(int offerInfoId)
        {
            var result = await DeleteAsync(x => x.OfferInfoId == offerInfoId);
            return result;
        }


    }
}
