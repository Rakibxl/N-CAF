using Architecture.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities
{
    public class Example : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
        public string ImageUrl { get; set; }
    }
}
