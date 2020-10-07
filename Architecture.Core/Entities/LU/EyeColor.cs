using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class EyeColor
    {
        public int EyeColorId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
