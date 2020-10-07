﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Architecture.Core.Entities.LU
{
    public class NationalIdType
    {
        public int NationalIdTypeId { get; set; }
        public string NationalIdTypeName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
