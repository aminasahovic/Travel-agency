using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.TuristickaAgencija.ViewModels
{
    public class TravelArrangementAddVM
    {
        public int DestinationID { get; set; }
        public int UserID { get; set; }
        public int TrnsportID { get; set; }
        public int AccomodationID { get; set; }
        public int NumberOfPerson { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
