using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;
using System;

namespace Architecture.Core.Entities
{
    public class ProfLegalInfo : Auditable
    {
        public int LegalInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? CountryNameId { get; set; }
        public virtual CountryName CountryName { get; set; }
        public string CityName { get; set; }
        public bool? IsAnyCase { get; set; }
        public string RefNo { get; set; }      
        public string Reason { get; set; }      
        public string Note { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
