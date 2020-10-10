using System;

namespace Architecture.Core.Entities.LU
{
    public class ContractType
    {
        public int ContractTypeId { get; set; }
        public string ContractTypeName { get; set; }
        public Boolean IsActive { get; set; } = true;
    }
}
