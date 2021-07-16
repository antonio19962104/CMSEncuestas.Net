using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class SenderEmail
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string BCC { get; set; }
        public string CC { get; set; }
        public int Priority { get; set; }
        public MailPriority MailPriority { get; set; }
    }
}
