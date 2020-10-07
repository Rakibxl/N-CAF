using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Entities.Core
{
    public abstract class Auditable
    {
        public Guid? CreatedBy { get; set; }

        public DateTime? Created { get; set; }

        public Guid? ModifiedBy { get; set; }

        public DateTime? Modified { get; set; }
    }
}
