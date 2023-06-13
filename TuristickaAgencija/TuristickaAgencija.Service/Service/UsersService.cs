using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Primitives;
using Repository.TuristickaAgenija.Repositories;
using Service.TuristickaAgencija.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Vonage;
using Vonage.Request;
using Vonage.Messages.WhatsApp;

namespace Service.TuristickaAgencija.Service
{
    public interface IUsersService
    {
        void Remove(int id);
        List<Users> GetAll();

        Users GetByUsernaeAndPassword(string username, string password);
        Users GetByEmail(string email);

        Users CheckIfItExists(UserLoginInfoVM user);

        bool Add(UsersAddVM obj);
        bool AddByEmployee(UsersAddVM obj);


        bool Update(DateTime tokenEx, string restartToken, int id);

        bool ChangePassword(string newPass, int id);

        bool ConfirmMail(int id);

        string getImgById(int id);
        bool SendSms(string number);
        bool SendWASms(string number);
        Users GetById(int id);
        List<TravelArrangement> GetByUserId(int userid);

    }
    public class UsersService : IUsersService
    {
        IUsersRepository usersRepository;
        IRepository<Users> usersReposBasic;
        ITravelArrangementService travelArrangmentRepository;
        public UsersService(IUsersRepository usersRepository, IRepository<Users> usersReposBasic, ITravelArrangementService travelArrangmentRepository)
        {
            this.usersRepository = usersRepository;
            this.usersReposBasic = usersReposBasic;
            this.travelArrangmentRepository = travelArrangmentRepository;
        }

        public bool Add(UsersAddVM obj)
        {
            var newBasicUser = new Users()
            {
                BirthDate = obj.BirthDate,
                FirsName = obj.FirstName,
                LastName = obj.LastName,
                IsEmailAccepted = false,
                IsAdmin = false,
                Password = PasswordHasher.HashPassword(obj.Password),
                Username = obj.Username,
                Email = obj.Email,
                Role = string.Empty,
                Token = string.Empty,
                ProfileImage = obj.ProfileImageBase64.parseBase64(),
                ProfileImageBase64 = obj.ProfileImageBase64Url


            };
            if (CheckEmail(newBasicUser.Email) && CheckUsername(newBasicUser.Username))
            {
                usersReposBasic.Add(newBasicUser);
                return true;

            }
            return false;
        }

        public Users CheckIfItExists(UserLoginInfoVM user)
        {
            var user_ = usersReposBasic.GetAll().FirstOrDefault(x => x.Username == user.Username);
            if (user_ != null)
            {
                if (!PasswordHasher.VerifyPassword(user.Password, user_.Password))
                {
                    return null;
                }
                return user_;
            }
            return null;

        }

        public bool CheckEmail(string mail)
        {
            var rez = usersReposBasic.GetAll().Find(x => x.Email == mail);
            if (rez == null) return true;
            return false;
        }
        public bool CheckUsername(string username)
        {
            var rez = usersReposBasic.GetAll().Find(x => x.Username == username);
            if (rez == null) return true;
            return false;
        }
        public static string ToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
        public List<Users> GetAll()
        {
            return usersRepository.getAll();
        }

        public Users GetByUsernaeAndPassword(string username, string password)
        {
            return usersRepository.GetByLogin(username, password);
        }

        public void Remove(int id)
        {
            var removeUser = usersRepository.GetById(id);
            usersReposBasic.Remove(removeUser);
        }

        public Users GetByEmail(string email)
        {
            return usersRepository.GetByEmail(email);
        }

        public bool Update(DateTime tokenEx, string restartToken, int id)
        {
            var user = usersRepository.GetById(id);
            if (user == null) return false;
            user.ResetPasswordToken = restartToken;
            user.ResetPasswordExpiry = tokenEx;
            usersReposBasic.Update(user);
            return true;
        }

        public bool ChangePassword(string newPass, int id)
        {
            var user = usersRepository.GetById(id);
            if (user == null) return false;
            user.Password = newPass;
            usersReposBasic.Update(user);
            return true;
        }

        public bool ConfirmMail(int id)
        {
            var user = usersRepository.GetById(id);
            if (user == null) return false;
            user.IsEmailAccepted = true;
            usersReposBasic.Update(user);
            return true;
        }


        public string getImgById(int id)
        {
            return usersRepository.getImgById(id);
        }

        public bool SendSms(string number)
        {
            var credentials = Credentials.FromApiKeyAndSecret(
                                                                "0e3ea8a6",
                                                                "jd5XaePGmCMjjtHh"
                                                                );

            var VonageClient = new VonageClient(credentials);


            var response = VonageClient.SmsClient.SendAnSms(new Vonage.Messaging.SendSmsRequest()
            {
                To = number,
                From = "SkyTravel",
                Text = "Pozdrav! SkyTravel ima sjajnu ponudu putovanja za vas! Pogledajte nasu web stranicu ili nas kontaktirajte za vise informacija. Sretno putovanje! -Amina&Husein SkyTravel Team  "
            });

            return true;
        }

        public bool SendWASms(string number)
        {
            return true;



        }

        public Users? GetById(int id)
        {
            return usersReposBasic.GetAll().Where(x => x.UsersID == id).FirstOrDefault();
        }

        public bool AddByEmployee(UsersAddVM obj)
        {
            var newBasicUser = new Users()
            {
                BirthDate = obj.BirthDate,
                FirsName = obj.FirstName,
                LastName = obj.LastName,
                IsEmailAccepted = true,
                IsAdmin = false,
                Password = PasswordHasher.HashPassword(obj.Password),
                Username = obj.Username,
                Email = obj.Email,
                Role = string.Empty,
                Token = string.Empty,
                ProfileImage = obj.ProfileImageBase64.parseBase64(),
                ProfileImageBase64 = obj.ProfileImageBase64Url


            };
            if (CheckEmail(newBasicUser.Email) && CheckUsername(newBasicUser.Username))
            {
                usersReposBasic.Add(newBasicUser);
                return true;

            }
            return false;
        }

        public List<TravelArrangement> GetByUserId(int userid)
        {
            return travelArrangmentRepository.GetByUserId(userid);
        }
    }
}
