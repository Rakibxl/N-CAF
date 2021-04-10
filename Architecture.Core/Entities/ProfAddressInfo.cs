using System;
using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
    public class ProfAddressInfo : Auditable
    {
        public int AddressInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? AddressTypeId { get; set; }
        public virtual AddressType AddressType { get; set; }
        public string RoadName { get; set; }
        public string RoadNo { get; set; }
        public string BuildingNo { get; set; }
        public string FloorNo { get; set; }
        public string AppartmentNo { get; set; }
        public string PostalCode { get; set; }
        public string CityName { get; set; }
        public int? ProvinceId { get; set; }
        public Province Province { get; set; }
        public string State { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Active { get; set; }

    }
}
