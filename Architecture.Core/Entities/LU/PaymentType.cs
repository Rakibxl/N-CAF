using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities.LU
{
   public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
