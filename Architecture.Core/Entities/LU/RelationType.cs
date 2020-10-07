using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class RelationType
    {
        public int RelationTypeId { get; set; }
        public string RelationTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
