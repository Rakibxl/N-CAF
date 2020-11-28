using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    interface ICRUDService<TEntity> where TEntity:class
    {
        Task<TEntity> GetById(int id);
        Task<TEntity> AddOrUpdate(TEntity data);
        Task<int> Delete(int id);
    }
}
