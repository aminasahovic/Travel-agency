using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Identity;
using Repository.TuristickaAgenija.Repositories;
using Service.TuristickaAgencija.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TuristickaAgencija.Service
{
    public interface IClientService
    {
        //void Add(ClientAddVM obj);
        bool Add(ClientAddVM obj);

        void Remove(int id);

        List<Client> GetAll();

        //List<Client> GetByName(string name);

    }
    public class ClientService:IClientService
    {
        IClientRepository clientRepository;
        IRepository<Client> clientReposBasic;
        IRepository<Users> userReposBasic;

        IUsersRepository userRepos;

        public ClientService(IClientRepository clientRepository, IRepository<Client> clientReposBasic, IUsersRepository userRepos)
        {
            this.clientRepository = clientRepository;
            this.clientReposBasic = clientReposBasic;
            this.userRepos = userRepos;
        }

        public bool Add(ClientAddVM obj)
        {
            var newCl = new Client()
            {
                Username = obj.Username,
                BirthDate = obj.BirthDate,
                Email = obj.Email,
                LastName = obj.LastName,
                Password = PasswordHasher.HashPassword(obj.Password),
                FirsName = obj.FirstName,
                Active = obj.Active,
                Membership = obj.Membership,
                IsAdmin = false,
                IsEmailAccepted = false,
            };

            if (CheckEmail(newCl.Email) && CheckUsername(newCl.Username))
            {
                clientReposBasic.Add(newCl);
                return true;

            }
            return false;

        }
        public Client CheckIfItExists(UserLoginInfoVM user)
        {
            var client_ = clientReposBasic.GetAll().FirstOrDefault(x => x.Username == user.Username);
            if (!PasswordHasher.VerifyPassword(user.Password, client_.Password))
            {
                return null;
            }
            return client_;
        }

        public bool CheckEmail(string mail)
        {
            var rez = clientReposBasic.GetAll().Find(x => x.Email == mail);
            if (rez == null) return true;
            return false;
        }
        public bool CheckUsername(string username)
        {
            var rez = clientReposBasic.GetAll().Find(x => x.Username == username);
            if (rez == null) return true;
            return false;
        }


        public List<Client> GetAll()
        {
            return clientRepository.GetByAll();
        }

     

        public void Remove(int id)
        {
            var client = clientRepository.GetById(id).FirstOrDefault();
            if (client != null)
                clientReposBasic.Remove(client);
        }
    }
}
