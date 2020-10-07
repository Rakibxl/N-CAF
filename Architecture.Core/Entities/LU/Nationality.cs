using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class Nationality
    {
        public int NationalityId { get; set; }
        public string NationalityName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
