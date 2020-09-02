using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Web.Core
{
    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string[] ErrorList { get; set; }
    }
}
