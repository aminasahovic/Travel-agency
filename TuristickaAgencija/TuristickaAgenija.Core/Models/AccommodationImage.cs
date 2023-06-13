using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class AccommodationImage
    {
        public int AccommodationImageID { get; set; }
        public int AccomodationID { get; set; }
        public byte[] ImageByteArray { get; set; }

        public Accommodation Accommodation { get; set; }
    }
}
