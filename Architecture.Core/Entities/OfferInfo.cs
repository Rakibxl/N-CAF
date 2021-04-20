using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities
{
    public class OfferInfo : Auditable
    {
        public int OfferInfoId { get; set; }       
        public int JobId { get; set; }
        public virtual JobInfo JobInfo { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public string AcceptedOperatorId { get; set; }
        public DateTime? OperatorAcceptedDate { get; set; }
        public string ValidatorId { get; set; }
        public DateTime? ValidationDate { get; set; }
        public int? OfferStatusId { get; set; }
        public virtual OfferStatus OfferStatus { get;set;}
        public string Status { get; set; }
        public Guid? CurrentUserId { get; set; }
        public string DocumentSrc { get; set; }
        public string Code { get { return $"NC-{this.OfferInfoId.ToString("D4")}"; } }

    }
}
