using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class OccupationType
    {
        public int OccupationTypeId { get; set; }
        public string OccupationTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
