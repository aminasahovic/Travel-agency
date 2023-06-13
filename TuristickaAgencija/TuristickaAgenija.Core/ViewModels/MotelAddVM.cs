using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.ViewModels
{
    public class MotelAddVM
    {
        public string Name { get; set; } = string.Empty;
        public bool Pass { get; set; }
        public int NumberOfRooms { get; set; }
        public int DestinationID { get; set; }
        public double Price { get; set; }
        public bool Parking { get; set; }
        public bool PetFriendly { get; set; }
    }
}
