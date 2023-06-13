using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class Transportation
    {
        public int TransportationId { get; set; }
        public string Name { get; set; }=string.Empty;
        public double Price { get; set; }
        public char Class { get; set; }
    }
}
