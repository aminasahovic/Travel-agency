using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class Office
    {
        public int OfficeID { get; set; }
        public string OfficeNumber { get; set; }
        public Department Department { get; set; }
    }
}
