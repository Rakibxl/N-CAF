using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
    public class JobSectionLink : Auditable
    {
        public int JobSectionLinkId { get; set; }
        public int? JobInfoId { get; set; }
        public int? SectionNameId { get; set; }
        public virtual SectionName SectionName { get; set; }

    }
}
