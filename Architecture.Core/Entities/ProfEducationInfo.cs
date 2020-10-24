using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;
using System;

namespace Architecture.Core.Entities
{
    public class ProfEducationInfo : Auditable
    {
        public int EducationInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? DegreeTypeId { get; set; }
        public virtual DegreeType DegreeType { get; set; }
        public string InstitutionName { get; set; }     
        public DateTime StartYear { get; set; }
        public DateTime EndYear { get; set; }
        public string UniversityAddress { get; set; }
        public string ActivitiesAndSocieties { get; set; }
        public string Result { get; set; }
    }
}
