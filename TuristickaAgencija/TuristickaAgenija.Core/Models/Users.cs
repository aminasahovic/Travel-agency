using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.TuristickaAgencija.Models
{
    public class Users
    {
        public int UsersID { get; set; }
        public string FirsName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public bool IsAdmin { get; set; }   
        public string Email { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsEmailAccepted { get; set; }
        public string? ResetPasswordToken { get; set; }
        public DateTime ResetPasswordExpiry { get; set; }
        public bool? isDeleted { get; set; }
        public string? ProfileImageBase64 { get; set; } // base64 kodirana slika
        public byte[]? ProfileImage { get; set; } // dekodirani byte niz slike
        public bool? twofactActive { get; set; }
        public string? twofcode { get; set; }
        public string? phoneNumber { get; set; }

    }
}
