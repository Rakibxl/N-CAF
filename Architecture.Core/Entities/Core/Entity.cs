using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Entities.Core
{
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public Entity()
        {
            //this.Id = Guid.NewGuid();
            this.IsDeleted = false;
            this.IsActive = true;
        }
    }
}
