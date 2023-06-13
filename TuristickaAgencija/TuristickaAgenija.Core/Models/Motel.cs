using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class Motel: Accommodation
    {
        public bool Parking { get; set; }
        public bool PetFriendly { get; set; }
    }
}
