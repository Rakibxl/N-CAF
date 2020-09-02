using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Repository.Core
{
    public interface IUnitOfWork : IDisposable
    {
        bool SaveChanges();
        void Rollback();
        Task<bool> SaveChangesAsync();
        public IDbContextTransaction BeginTransaction();
        public Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
