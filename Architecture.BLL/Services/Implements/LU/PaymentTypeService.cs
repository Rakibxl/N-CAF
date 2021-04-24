using Architecture.BLL.Services.Interfaces.LU;
using Architecture.Core.Entities.LU;
using Architecture.Core.Repository.Context;
using Architecture.Core.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.BLL.Services.Implements.LU
{
   public class PaymentTypeService : Repository<PaymentType>, IPaymentTypeService
    {
        public PaymentTypeService(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<IEnumerable<PaymentType>> GetAll()
    {
        IEnumerable<PaymentType> result;
        result = await GetAsync(x => x, x => x.IsActive == true);
        return result;
    }

    public async Task<PaymentType> GetById(int id)
    {
        var checkVal = await IsExistsAsync(x => x.PaymentTypeId == id);
        if (checkVal)
        {
            PaymentType result = await GetByIdAsync(id);
            return result;
        }
        else
        {
            throw new Exception("Information is not exists.");
        }
    }

    public async Task<PaymentType> AddOrUpdate(PaymentType paymentType)
    {
        try
        {
            PaymentType result;
            if (paymentType.PaymentTypeId > 0)
            {
                result = await UpdateAsync(paymentType);
            }
            else
            {
                result = await AddAsync(paymentType);
            }
            return result;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<int> Delete(int id)
    {
        var result = await DeleteAsync(x => x.PaymentTypeId == id);
        return result;
    }
}
}
