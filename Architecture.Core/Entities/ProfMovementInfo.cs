using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;
using System;

namespace Architecture.Core.Entities
{
    public class ProfMovementInfo : Auditable
    {
        public int MovementInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? CountryNameId { get; set; }
        public virtual CountryName CountryName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Purpose { get; set; }
        public string Status { get; set; }

    }
}
