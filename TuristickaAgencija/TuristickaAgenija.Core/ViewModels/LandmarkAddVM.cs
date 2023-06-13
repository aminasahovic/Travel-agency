using Core.TuristickaAgencija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.ViewModels
{
    public class LandmarkAddVM
    {
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public int CityId { get; set; }
    }
}
