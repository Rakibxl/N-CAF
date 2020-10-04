using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class GenderType
    {
        [Key]
        public int GenderTypeId { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
