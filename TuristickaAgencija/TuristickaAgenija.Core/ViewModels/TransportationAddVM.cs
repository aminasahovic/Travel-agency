using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.ViewModels
{
    public class TransportationAddVM
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public char Class { get; set; }
    }
}
