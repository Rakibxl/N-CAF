using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class ResidenceScope
    {
        public int ResidenceScopeId { get; set; }
        public string ResidenceScopeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
