using Core.TuristickaAgencija.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TuristickaAgencija.Service
{
    
    public interface IEmailService
    {
        void SendEmail(Email email, int type);
    }
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(Email email, int type)
        {
            var emailm = new MimeMessage();
            var from = "skytravel.rs1.amina.husein@gmail.com";
            if (type == 1)
            {
                emailm.From.Add(new MailboxAddress("SKYTRAVEL - RESTART LOZINKE ", from));
                emailm.Subject = "SKYTRAVEL :: Restart lozinke";
            }
            else if(type == 2)
            {
                emailm.From.Add(new MailboxAddress("SKYTRAVEL - POTVRDA MAILA ", from));
                emailm.Subject = "SKYTRAVEL :: Potvrda maila";
            }
            else if(type == 4)
            {
                emailm.From.Add(new MailboxAddress("SKYTRAVEL - NOVA PONUDA", from));
                emailm.Subject = "SKYTRAVEL - NOVA PONUDA SAMO ZA VAS";
            }
            else
            {
                emailm.From.Add(new MailboxAddress("SKYTRAVEL - OBAVIJEST", from));
                emailm.Subject = "SKYTRAVEL";
            }
          
            emailm.To.Add(new MailboxAddress(email.To, email.To));
            
            emailm.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format(email.Content)
            };

            using(var client= new SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("skytravel.rs1.amina.husein@gmail.com", "bkwzroplqzdsernj");
                    client.Send(emailm);
                }
                catch(Exception ex)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }

    }
}
