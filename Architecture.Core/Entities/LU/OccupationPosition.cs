using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class OccupationPosition
    {
        public int OccupationPositionId { get; set; }
        public string OccupationPositionName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
