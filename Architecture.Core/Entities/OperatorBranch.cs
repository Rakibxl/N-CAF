using Architecture.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities
{
    public class OperatorBranch : Auditable
    {
        [Key]
        public int OperatorBranchId { get; set; }
        public Guid ApplicationUserId { get; set; }
        public int BranchInfoId { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        //public virtual BranchInfo BranchInfo { get; set; }
    }
}
