using Architecture.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities
{
    public class OperatorBranch : Auditable
    {
        public Guid ApplicationUserId { get; set; }
        public int BranchInfoId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual BranchInfo BranchInfo { get; set; }
    }
}
