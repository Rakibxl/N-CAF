using System;
using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
    public class ProfIncomeInfo : Auditable
    {
        public int IncomeInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? IncomeTypeId { get; set; }
        public virtual IncomeType IncomeType { get; set; }
        public decimal YearlyIncome { get; set; }
        public decimal MonthlyIncome { get; set; }        
        public string Year { get; set; }
        public string Month { get; set; }
        public string Document { get; set; }
        public string Status { get; set; }

    }
}
