using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class Accommodation
    {
        public int AccommodationID { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Pass { get; set; }
        public int NumberOfRooms { get; set; }
        public double Price { get; set; }
        public Destination Destination { get; set; }
        public City City { get; set; }
    }
}
