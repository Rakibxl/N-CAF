using System;
using Architecture.Core.Entities.Core;
using Architecture.Core.Entities.LU;

namespace Architecture.Core.Entities
{
    public class ProfWorkerInfo : Auditable
    {
        public int WorkerInfoId { get; set; }
        public int ProfileId { get; set; }
        public virtual ProfBasicInfo ProfBasicInfo { get; set; }
        public int? WorkerTypeId { get; set; }
        public virtual WorkerType WorkerType { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string TaxCode { get; set; }
        public string ContractNumber { get; set; }
        public decimal MonthlySalary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Active { get; set; }

    }
}
