using Architecture.Core.Entities;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Repository.Implements
{
    public class ExampleRepository : Repository<Example, int, ApplicationDbContext>, IExampleRepository
    {
        public ExampleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
