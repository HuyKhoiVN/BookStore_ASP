using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Data.Utitlities
{
    public class TwilioSettings
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string AuthToken { get; set; } = string.Empty;
        public string AccountSid { get; set; } = string.Empty;

    }
}
