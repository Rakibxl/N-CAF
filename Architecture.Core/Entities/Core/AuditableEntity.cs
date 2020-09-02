using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Entities.Core
{
    public abstract class AuditableEntity<TKey> : Entity<TKey>
    {
        public Guid? CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public Guid? LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
