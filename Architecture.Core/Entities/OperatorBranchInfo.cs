using System;
using System.Collections.Generic;
using Architecture.Core.Entities.Core;

namespace Architecture.Core.Entities
{
    public class OperatorBranchInfo : Auditable
    {
        public Guid ApplicationUserId { get; set; }
        public int BranchInfoId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual BranchInfo BranchInfo { get; set; }
    }
}
