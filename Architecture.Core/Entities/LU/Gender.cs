using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
