using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class DestinationImage
    {
        [Key]
        public int DestinationImageID { get; set; }
        public int DestinationID { get; set; }
        public byte[] ImageByteArray { get; set; }

        [ForeignKey("DestinationID")]
        public Destination Destination { get; set; }

    }
}
