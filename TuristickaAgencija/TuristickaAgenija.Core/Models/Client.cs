using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class Client: Users
    {
        public bool Active { get; set; }
        public string Membership { get; set; }=string.Empty;
    }
}
