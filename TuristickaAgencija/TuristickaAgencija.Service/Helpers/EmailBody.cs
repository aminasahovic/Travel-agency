using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TuristickaAgencija.Helpers
{
    public static class EmailBody
    {
        public static string EmailStringBody(string email, string emailToken, string name, int type=1, string ponuda="", double cijena=0)
        {
            if (type == 1)
            {
                return $@"
<html>
  <head>
  </head>
  <body style=""font-family: Arial, sans-serif; font-size: 16px; line-height: 1.5; color: #333;"">
    <h1 style=""font-size: 24px; margin-top: 0; margin-bottom: 20px;"">Restart lozinike za SkyTravel nalog</h1>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Pozdrav {name}, <br></p>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Zaprimili smo Vaš zahtjev za promjenu Vaše SkyTravel lozinke. Ukoliko Vi to niste zahtjevali molimo Vas da zanemarite ovaj mail.</p>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Da biste restartovali Vašu lozinku dovoljno je da kliknete na dugme ispod:</p>
    <a href=""http://localhost:4200/reset?email={email}&code={emailToken}"" target=""_balnk"" style=""display: inline-block; background-color: #007bff; color: #fff; text-decoration: none; padding: 10px 20px; border-radius: 5px; margin-bottom: 20px;"">Restartuj lozinku</a>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Ili kliknite ovdje:</p>
    <p style=""margin-top: 0; margin-bottom: 20px;"">http://localhost:4200/reset?email={email}&code={emailToken}</p>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Link za restart lozinke će isteći za 60 minuta.</p>
    <p class=""footer"" style=""margin-top: 50px; font-size: 14px; color: #888;"">Srdačan pozdrav,<br>SkyTravel Tim - Amina&Husein</p>
  </body>
</html>

";

            }

            else if (type == 2)
            {
                return $@"
<html>
  <head>
  </head>
  <body style=""font-family: Arial, sans-serif; font-size: 16px; line-height: 1.5; color: #333;"">
    <h1 style=""font-size: 24px; margin-top: 0; margin-bottom: 20px;"">Potvrda maila za SkyTravel nalog</h1>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Pozdrav {name}, <br></p>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Drago nam je da ste se odlučili da korisite usluge SkyTravel. Ukoliko Vi to niste zahtjevali molimo Vas da zanemarite ovaj mail.</p>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Da biste potvrdili Vašu email adresu dovoljno je da kliknete na dugme ispod:</p>
    <a href=""http://localhost:4200/confirm?email={email}&code={emailToken}"" target=""_balnk"" style=""display: inline-block; background-color: #007bff; color: #fff; text-decoration: none; padding: 10px 20px; border-radius: 5px; margin-bottom: 20px;"">Potvrdi mail</a>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Ili kliknite ovdje:</p>
    <p style=""margin-top: 0; margin-bottom: 20px;"">http://localhost:4200/confirm?email={email}&code={emailToken}</p>
    <p class=""footer"" style=""margin-top: 50px; font-size: 14px; color: #888;"">Srdačan pozdrav,<br>SkyTravel Tim - Amina&Husein</p>
  </body>
</html>

";
            }
            else if (type==4)
            {
                return $@"
<html>
  <head>
  </head>
  <body style=""font-family: Arial, sans-serif; font-size: 16px; line-height: 1.5; color: #333;"">
    <h1 style=""font-size: 24px; margin-top: 0; margin-bottom: 20px;"">Nova ponuda po cijeni od {cijena} KM</h1>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Pozdrav {name}, <br></p>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Upravo smo dodali novu ponudu {ponuda}, za koju vjerujemo da će Vam se svidjeti. </p>
    <a href=""http://localhost:4200/"" target=""_balnk"" style=""display: inline-block; background-color: #007bff; color: #fff; text-decoration: none; padding: 10px 20px; border-radius: 5px; margin-bottom: 20px;"">Pogledaj ponudu</a>
    <p class=""footer"" style=""margin-top: 50px; font-size: 14px; color: #888;"">Srdačan pozdrav,<br>SkyTravel Tim - Amina&Husein</p>
  </body>
</html>

";
            }
            else
            {
                return $@"
<html>
  <head>
  </head>
  <body style=""font-family: Arial, sans-serif; font-size: 16px; line-height: 1.5; color: #333;"">
    <h1 style=""font-size: 24px; margin-top: 0; margin-bottom: 20px;"">Dugo Vas nema na vašem SkyTravel nalogu</h1>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Pozdrav {name}, <br></p>
    <p style=""margin-top: 0; margin-bottom: 20px;"">Pogledajte šta ima novo u SkyTravel ponudi </p>
    <p class=""footer"" style=""margin-top: 50px; font-size: 14px; color: #888;"">Srdačan pozdrav,<br>SkyTravel Tim - Amina&Husein</p>
  </body>
</html>

";
            }


            //            return $@"
            //<html>
            //<head>
            //</head>
            //<body>
            //<div>
            //<div>
            //<div>
            //<h1>RESTART LOZINIKE SkyTravel</h1>
            //<hr>
            //<p>Pozdrav {name} jako nam je žao, što imate poteškoće prilikom pristupanja Vašem SkyTravel nalogu.</p>
            //<p>Međutim, tu smo da Vam pomognemo.</p>
            //<p>Klikom na link ispod imat ćete mogućnost da restartujete Vašu lozinku.</p>
            //<p><a href=""http://localhost:4200/reset?email={email}&code={emailToken}"" target=""_balnk"">RESTARTUJ LOZINKU</a></p>
            //<p> Srdačan pozdrav, <br><br> SkyTravelTim 
            //</p>
            //<hr>
            //<p> <br> Za dodatna pitanja javite se na ovaj mail</p>
            //</div>
            //</div>
            //</div>
            //</body>
            //</html>

            //            ";
        }
    }
}
