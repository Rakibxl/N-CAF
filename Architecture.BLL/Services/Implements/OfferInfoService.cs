using Architecture.BLL.Services.Interfaces;
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
    public class OfferInfoService: IOfferInfoService// Repository<JobInfo>
    {
        private readonly IJobInformationService jobInfoService;
        public OfferInfoService(ApplicationDbContext dbContext, IJobInformationService jobInfoService) //: base(dbContext)
        {
            this.jobInfoService = jobInfoService;
        }

        public async Task<IEnumerable<JobInfo>> GetMyOffer()
        {
            var result = await jobInfoService.GetAll();
            return result;
        }
    }
}
