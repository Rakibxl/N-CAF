using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;
using Architecture.BLL.Services.Interfaces;
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
using Architecture.BLL.Services.ClientProfile.Interfaces;
using Architecture.Core.Repository.Interfaces;
using Architecture.Core.Repository.Interfaces.ClientProfile;

namespace Architecture.BLL.Services.ClientProfile.Implements
{
    public class ClientProfileService : IClientProfileService
    {
        private readonly IClientProfileRepository _clientProfileRepository;

        public ClientProfileService(IClientProfileRepository clientProfileRepository)
        {
            _clientProfileRepository = clientProfileRepository;
        }

        public async Task<int> AddUpdate(ProfBasicInfo entity)
        {
            //using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            //{
            try
            {
                //var isExists = await this.IsExistsUserNameAsync(entity.UserName, entity.Id);
                //if (isExists)
                //{
                //    throw new DuplicationException(nameof(entity.Email));
                //}

                entity.Created = DateTime.Now; //_dateTime.Now;
                entity.CreatedBy = Guid.NewGuid(); //_currentUserService.UserId;

                await _clientProfileRepository.AddAsync(entity);
                //if (!result.Succeeded)
                //{
                //    throw new IdentityValidationException(result.Errors);
                //};

                //scope.Complete();

                return entity.ProfileId;
            }
            catch (Exception ex)
            {
                //scope.Dispose();
                throw ex;
            }
            //}
        }
    }
}
