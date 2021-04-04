using Architecture.Core.Entities;
using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.BLL.Services.Models
{
    public class OfferInfoVM : Auditable
    {
        public int OfferInfoId { get; set; }
        public int JobId { get; set; }
        public virtual JobInfo JobInfo { get; set; }
        public int ProfileId { get; set; }
        public ProfBasicInfo ProfBasicInfo { get; set; }
        public string ProfileName { get; set; }
        public string AcceptedOperatorId { get; set; }
        public string AcceptedOperatorName{ get; set; }
        public DateTime? OperatorAcceptedDate { get; set; }
        public string ValidatorId { get; set; }
        public string ValidatorName { get; set; }
        public DateTime? ValidationDate { get; set; }
        public int? OfferStatusId { get; set; }
        public virtual OfferStatus OfferStatus { get; set; }
        public string Status { get; set; }
        public Guid? CurrentUserId { get; set; }
    }
}
