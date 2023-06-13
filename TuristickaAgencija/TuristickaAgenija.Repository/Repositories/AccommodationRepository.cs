using Core.TuristickaAgencija.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgenija.Repository;

namespace Repository.TuristickaAgenija.Repositories
{
    public interface IAccommodationRepositroy
    {
        List<Accommodation> GetAllAccommodation();
        Accommodation GetById(int id);
        bool ifExistDestination(int id);
        List<Accommodation> GetByCity(string city);

    }
    public class AccommodationRepository : Repository<Accommodation>, IAccommodationRepositroy
    {
        DbSet<Accommodation> _dbSet;
        public AccommodationRepository(TuristickaAgencijaDbContext db) : base(db)
        {
            _dbSet = db.Set<Accommodation>();
        }

        public List<Accommodation> GetAllAccommodation()
        {
            return _dbSet.Include(d=>d.Destination).Include(d=> d.Destination.City).Include(d=>d.City).ToList();
        }

        public List<Accommodation> GetByCity(string city)
        {
            return _dbSet.Where(x => x.Destination.City.CityName.Contains(city)).ToList();

        }

        public Accommodation GetById(int id)
        {
            return _dbSet.Where(x => x.AccommodationID == id).FirstOrDefault();
        }

        public bool ifExistDestination(int id)
        {
            var value= _dbSet.Where(x => x.Destination.DestinationID == id).FirstOrDefault();
            if (value != null) return true;
            return false;
        }
       
       
    }
}
