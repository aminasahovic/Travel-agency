using Core.TuristickaAgencija.Models;
using Repository.TuristickaAgenija.Repositories;

namespace Service.TuristickaAgencija.Service
{
    public interface IKorisnikService
    {
        void Add(User obj);
        IEnumerable<User> GetKorisnici();

    }
    public class KorisnikService : IKorisnikService
    {
        IRepository<User> korisnikRepository;
        public KorisnikService(IRepository<User> korisnikRepository)
        {
            this.korisnikRepository = korisnikRepository;
        }

        public void Add(User obj)
        {
            korisnikRepository.Add(obj);
        }

        public IEnumerable<User> GetKorisnici()
        {
            return korisnikRepository.GetAll();
        }
    }
}