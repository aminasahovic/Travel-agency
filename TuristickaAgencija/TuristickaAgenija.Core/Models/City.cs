using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CityPostalCode { get; set; }

        public Country Country { get; set; }
    }
}
