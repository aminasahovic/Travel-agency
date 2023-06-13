using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class Destination
    {
        public int DestinationID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rate { get; set; }
        public string Describe { get; set; } = string.Empty;
        public double Price { get; set; }
        public City City { get; set; }
    }
}
