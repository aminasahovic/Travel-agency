using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class Email
    {
        //bkwzroplqzdsernj
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Email(string to, string subject, string content)
        {
            To = to;
            Subject = subject;
            Content = content;
        }
    }
}
