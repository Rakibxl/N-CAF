using Architecture.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities.Notification
{
    public class NotificationInfo: Auditable
    {
        public int NotificationInfoId { get; set; }
        public string MessageContent { get; set; }
        public int? ParentMessageId { get; set; }
        public bool IsGlobal { get; set; }
        public Guid? MessageFor { get; set; }
        public bool IsSeen { get; set; }
        public DateTime? SeenTime { get; set; }
        public int? OfferInfoId { get; set; }
        public virtual OfferInfo OfferInfo { get; set; }
        public string Type { get; set; }
    }
}
