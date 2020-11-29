using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Architecture.Core.Entities.Core;
using System.ComponentModel.DataAnnotations.Schema;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
    public class BranchInfo: Auditable
    {
        [Key]
        public int BranchId { get; set; }
        public string BranchLocation { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? AgreementStart { get; set; }
        public int? NumberOfUser { get; set; }
        public bool? IsLocked { get; set; }
        public string Note { get; set; }
    }
}
