using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
    public class SectionLink : Auditable
    {
        public int SectionLinkId { get; set; }
        public string Title { get; set; }
        public string ActionLink { get; set; }
        public int? SectionNameId { get; set; }
        public virtual SectionName SectionName { get; set; }
        public string Remarks { get; set; } 

    }
}
