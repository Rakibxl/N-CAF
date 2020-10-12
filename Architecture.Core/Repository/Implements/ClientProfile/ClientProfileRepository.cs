using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Interfaces;
using Architecture.Core.Repository.Interfaces.ClientProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Repository.Implements.ClientProfile
{
    public class ClientProfileRepository : Repository<ProfBasicInfo, int, ApplicationDbContext>, IClientProfileRepository
    {
        //public IClientProfileRepository _clientProfileRepository { get; set; }

        public ClientProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            //_clientProfileRepository = clientProfileRepository;
        }
    }
}
