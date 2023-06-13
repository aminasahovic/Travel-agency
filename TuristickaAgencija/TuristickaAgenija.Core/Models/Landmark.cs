using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class Landmark
    {
        public int LandmarkID { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public City City { get; set; }
    }
}
