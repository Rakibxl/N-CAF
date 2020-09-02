using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using Architecture.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Repository.Implements
{
    public class ExampleUnitOfWork : UnitOfWork, IExampleUnitOfWork
    {
        public IExampleRepository ExampleRepository { get; set; }

        public ExampleUnitOfWork(ApplicationDbContext dbContext, IExampleRepository exampleRepository) : base(dbContext)
        {
            ExampleRepository = exampleRepository;
        }
    }
}
