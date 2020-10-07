using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class LoanInterestType
    {
        public int LoanInterestTypeId { get; set; }
        public string LoanInterestTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
