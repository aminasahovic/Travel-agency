using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class TravelArrangement
    {
        public int TravelArrangementID { get; set; }
        public Destination Destination { get; set; }
        public Users Users { get; set; }
        public Transportation Transportation { get; set; }
        public Accommodation Accommodation { get; set; }
        public int NumberOfPerson { get; set; }
        public double Price { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime? ArrivalTime { get; set; }


    }
}
