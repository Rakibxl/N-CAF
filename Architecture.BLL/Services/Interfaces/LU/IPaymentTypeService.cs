using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Interfaces.LU
{
   public interface IPaymentTypeService
    {
        Task<IEnumerable<PaymentType>> GetAll();
        Task<PaymentType> GetById(int id);
        Task<PaymentType> AddOrUpdate(PaymentType paymentType);
        Task<int> Delete(int id);
    }
}
