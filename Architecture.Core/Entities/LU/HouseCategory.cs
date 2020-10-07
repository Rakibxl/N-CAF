using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class HouseCategory
    {
        public int HouseCategoryId { get; set; }
        public string HouseCategoryName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
