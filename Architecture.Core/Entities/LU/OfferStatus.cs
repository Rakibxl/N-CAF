using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class OfferStatus
    {
        public int OfferStatusId { get; set; }
        public string OfferStatusName { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsEmailNotification { get; set; } = true;
        public bool IsApplicationNotification { get; set; } = true;
    }
}
