using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Web.Core
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
        public string FromEmail { get; set; }
        public string FromName { get; set; }
        public string ResetPasswordUrl { get; set; }
    }
}
