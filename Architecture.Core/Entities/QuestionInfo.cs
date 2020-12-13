using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
    public class QuestionInfo : Auditable
    {
        public int QuestionInfoId { get; set; }
        public string QuestionDescription { get; set; }
        public string PageToUrl { get; set; }
        public int? SectionNameId { get; set; }
        public virtual SectionName SectionName { get; set; }
        public string Status { get; set; } 

    }
}
