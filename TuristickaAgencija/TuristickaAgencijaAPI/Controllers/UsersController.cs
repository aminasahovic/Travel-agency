using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Service.TuristickaAgencija.Helpers;
using Service.TuristickaAgencija.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TuristickaAgenija.Repository;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using MimeKit;


namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService usersService;
        private readonly TuristickaAgencijaDbContext appContext;
        private readonly IConfiguration configuration;
        private readonly IEmailService _emailService;
        public UsersController(IUsersService service, IConfiguration con, IEmailService emailService, TuristickaAgencijaDbContext d)
        {
            usersService = service;
            configuration = con;
            _emailService = emailService;
            appContext = d;
        }
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetAllCity()
        {
            return Ok(usersService.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<List<Users>>> AddBasicUser(UsersAddVM user)
        {
            usersService.Add(user);
            return Ok(usersService.GetAll());
        }
        [HttpGet("username/{username}")]
        public async Task<ActionResult<Users>> GetLogin(string username, string password)
        {
            return Ok(usersService.GetByUsernaeAndPassword(username, password));
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserLoginInfoVM users)
        {
            if (users == null)
                return BadRequest(new { Message = "Check your input" });
            if (users.Username == "" || users.Password == "")
                return NotFound(new { Message = "Username and password are required" });

            var user = usersService.CheckIfItExists(users);
            if (user == null)
                return NotFound(new { Message = "User Not Found" });

            if (user.IsEmailAccepted == false)
                return BadRequest(new { Message = "Potvrdite mail" });
            user.Token = CreateJWT(user);

            return Ok(new
            {
                Token = user.Token,
                Message = "Login Success"
            });

        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisteruSER(UsersAddVM user)
        {
            if (user == null)
                return BadRequest();

            var check = usersService.Add(user);

            if (!check)
                return BadRequest("U bazi već postoji korisnik sa istim mailom");

            ConfirmMail(user.Email);
            return Ok(new { Message = "User registered" });
        }

        [HttpPost("registerbyEmployee")]
        public async Task<IActionResult> Register(UsersAddVM user)
        {
            if (user == null)
                return BadRequest();

            var check = usersService.AddByEmployee(user);

            if (!check)
                return BadRequest("U bazi već postoji korisnik sa istim mailom");

            return Ok(new { Message = "User registered" });
        }

        [HttpPost("ConfirmMail")]
        public async Task<IActionResult> ConfirmMail(string mail)
        {
            var user = usersService.GetByEmail(mail);
            if (user is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Meessage = "Email ne postoji u bazi"
                });
            }
            var tokenBytes = RandomNumberGenerator.GetBytes(6);
            var emailtoken = Convert.ToBase64String(tokenBytes);
            var emailModel = new Email(mail, "Potvrda maila - SkyTravel", EmailBody.EmailStringBody(mail, emailtoken, user.FirsName + " " + user.LastName, 2));
            _emailService.SendEmail(emailModel, 2);
            return Ok();
        }

        [HttpPost("emailconfirm/{mail}")]
        public async Task<IActionResult> Confirm(string mail)
        {

            var user = usersService.GetByEmail(mail);
            if (user is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Meessage = "Korisnik ne postoji u bazi"
                });
            }
            usersService.ConfirmMail(user.UsersID);
            return Ok();
        }

        [HttpGet("GetProfileImgById")]
        public async Task<IActionResult> GetProfileImgById(int id)
        {
            string img = usersService.getImgById(id);
            return await Task.FromResult(Ok(img));
        }


        [HttpPost("EmaiAll")]
        public async Task<IActionResult> Obavijesti()
        {
            for (int i = 0; i < usersService.GetAll().Count(); i++)
            {
                if (usersService.GetAll()[i].IsEmailAccepted == true)
                {
                    var email = usersService.GetAll()[i].Email;
                    var user = usersService.GetAll()[i];
                    var emailModel = new Email(email, "SkyTravel", EmailBody.EmailStringBody(email, "", user.FirsName + " " + user.LastName, 3));
                    _emailService.SendEmail(emailModel, 3);
                }
            }
            return Ok();
        }

        [HttpPost("send-reset-email/{email}")]
        public async Task<IActionResult> SendEmail(string email)
        {
            var user = usersService.GetByEmail(email);
            if (user is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Meessage = "Email ne postoji u bazi"
                });
            }
            if (user.IsEmailAccepted == false)
            {
                return BadRequest(new { Message = "Nazalost mail nije potvrđen" });
            }
            var tokenBytes = RandomNumberGenerator.GetBytes(6);
            var emailtoken = Convert.ToBase64String(tokenBytes);
            user.ResetPasswordToken = emailtoken;
            user.ResetPasswordExpiry = DateTime.Now.AddMinutes(60);
            string from = "skytravel.rs1.amina.husein@gmail.com";
            var emailModel = new Email(email, "Restart lozinike - SkyTravel", EmailBody.EmailStringBody(email, emailtoken, user.FirsName + " " + user.LastName));
            _emailService.SendEmail(emailModel, 1);
            usersService.Update(DateTime.Now.AddMinutes(60), emailtoken, user.UsersID);
            return Ok();
        }

        [HttpPost("sendSMS")]
        public async Task<IActionResult> SendSMS(string number)
        {
            return Ok(usersService.SendSms(number));
        }

        [HttpPost("reset-email")]

        public async Task<IActionResult> ResetPassword(RestartPassword r)
        {
            var newToken = r.EmailToken.Replace(" ", "+");
            var user = usersService.GetByEmail(r.Email);
            if (user is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Meessage = "Korisnik ne postoji u bazi"
                });
            }
            var tokenCode = user.ResetPasswordToken;
            DateTime emailTokenExpiry = user.ResetPasswordExpiry;
            if (tokenCode != r.EmailToken || emailTokenExpiry < DateTime.Now)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Nevalidan restart-link"
                });
            }

            var newPassword = PasswordHasher.HashPassword(r.NewPassword);
            usersService.ChangePassword(newPassword, user.UsersID);
            return Ok();
        }


        private string CreateJWT(Users users)
        {
            var jwtToken = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, users.Role),
                new Claim(ClaimTypes.Name, $"{users.FirsName} {users.LastName}"),
                new Claim("UserID", users.UsersID.ToString())

            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials,
            };
            var token = jwtToken.CreateToken(tokenDescriptor);
            return jwtToken.WriteToken(token);
        }


        [HttpGet("GetProfileById")]
        public Users GetProfileByIdUser(int id)
        {

            return usersService.GetById(id);
        }


        [HttpGet("generatePdf")]
        public async Task<IActionResult> GeneratePdf(int id)
        {

            var document = new PdfDocument();
            var header = usersService.GetById(id);
            string htmlcontent = "<div style='width:100%; text-align:center'>";
            htmlcontent += "<h2>SkyTravel izvještaj o korisnicima</h2>";
            htmlcontent += "<br/>";
            htmlcontent += "<br/>";
            htmlcontent += "<div style='width:100%; text-align:left' > ";
            htmlcontent += "<h3> Ime i prezime: " + header.FirsName + " " + header.LastName + "</h3>";
            htmlcontent += "<h3> Datum rođenja: " + header.BirthDate + "</h3>";
            htmlcontent += "<h3> Email: " + header.Email + "</h3>";
            htmlcontent += "<br/>";
            htmlcontent += "<h3>Aranzmani:<h3/>";
            htmlcontent += "<table style ='width:100%; border: 1px solid #000'>";
            htmlcontent += "<thead style='font-weight:bold'>";
            htmlcontent += "<tr>";
            htmlcontent += "<td style='border:1px solid #000'> Destinacija naziv </td>";
            htmlcontent += "<td style='border:1px solid #000'> Grad </td>";
            htmlcontent += "<td style='border:1px solid #000'>Prevoz</td>";
            htmlcontent += "<td style='border:1px solid #000'>Datum odlaska</td >";
            htmlcontent += "<td style='border:1px solid #000'>Cijena</td>";
            htmlcontent += "<td style='border:1px solid #000'>Total</td>";

            htmlcontent += "</tr>";
            htmlcontent += "</thead >";

            htmlcontent += "<tbody>";
            var arr = usersService.GetByUserId(id);
            if (arr != null)
            {
                double total = 0;
                arr.ForEach(item =>
                {
                    htmlcontent += "<tr>";
                    htmlcontent += "<td>" + item.Destination.Name + "</td>";
                    htmlcontent += "<td>" + item.Destination.City + "</td>";
                    htmlcontent += "<td>" + item.Transportation.Name + "</td >";
                    htmlcontent += "<td>" + item.DepartureTime + "</td>";
                    htmlcontent += "<td> " + item.Price + "</td >";
                    total += item.Price;
                    htmlcontent += "</tr>";

                });
                htmlcontent += "<tr>";
                htmlcontent += "<td style='border:1px solid #000'> " + " Total: " + total + "</td >";
                htmlcontent += "</tr >";

            }
            else
            {
                htmlcontent = "<div style='width:100%; text-align:center'>";
                htmlcontent += "Korisnik još uvijek nije kreirano ponude";
            }
             
            

           
            //htmlcontent += "<h3> Customer : " + header.CustomerName + "</h3>";
            //htmlcontent += "<p>" + header.DeliveryAddress + "</p>";
            //htmlcontent += "<h3> Contact : 9898989898 & Email :ts@in.com </h3>";
            //htmlcontent += "<div>";
            PdfGenerator.AddPdfPages(document, htmlcontent, PageSize.A4);
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string Filename = "Izvjestaj" + id + ".pdf";


            return File(response, "application/pdf", Filename);
        }
    }
}
