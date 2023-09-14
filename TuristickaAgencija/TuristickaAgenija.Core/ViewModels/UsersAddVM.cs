using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.ViewModels
{
    public class UsersAddVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string? Role { get; set; } = string.Empty;
        public bool TwoFA { get; set; } = false;
        public string? ProfileImageBase64 { get; set; }
        public string? ProfileImageBase64Url { get; set; } // base64 kodirana slika


    }
}
