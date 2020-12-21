using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
    public interface IJobDeliveryTypeService
    {
        Task<IEnumerable<JobDeliveryType>> GetAll();
        Task<JobDeliveryType> GetById(int id);
        Task<JobDeliveryType> AddOrUpdate(JobDeliveryType data);
        Task<int> Delete(int id);
    }
}


