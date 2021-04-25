using System;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities.Core
{
    public abstract class Auditable
    {
        public Guid? CreatedBy { get; set; }
        public DateTime Created { get; set; }

        public Guid? ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
        public int? RecordStatusId { get; set; }
        public RecordStatus RecordStatus { get; set; }
    }
}
