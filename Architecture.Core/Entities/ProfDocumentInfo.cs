using System;
using System.Collections.Generic;
using System.Text;
using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
    public class ProfDocumentInfo : Auditable
    {
        public int DocumentInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? DocumentTypeId { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public string DocumentName { get; set; }
        public string IssuedBy { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string PurposeOfDocument { get; set; }
    }
}
