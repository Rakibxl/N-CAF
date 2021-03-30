using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities.LU
{
   public class Province
    {
        public int ProvinceId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;


    }
}
