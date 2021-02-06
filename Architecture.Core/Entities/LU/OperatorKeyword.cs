using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.Core.Entities.LU
{
   public class OperatorKeyword
    {
        public int OperatorKeywordId { get; set; }
        public string OperatorKeywordName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
