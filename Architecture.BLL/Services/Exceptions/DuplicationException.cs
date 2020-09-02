using System;
using System.Collections.Generic;
using System.Text;

namespace Architecture.BLL.Services.Exceptions
{
    public class DuplicationException : Exception
    {
        public DuplicationException(string name)
            : base($"{name} already exists.")
        {
        }
    }
}
