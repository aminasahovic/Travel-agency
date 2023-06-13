using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.ViewModels
{
    public class ClientAddVM
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }
        public bool Active { get; set; }
        public string Membership { get; set; } = string.Empty;
    }
}
