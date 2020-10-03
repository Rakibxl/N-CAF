using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class MeriatalStatus
    {
        [Key]
        public int MeritalStatusId { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
