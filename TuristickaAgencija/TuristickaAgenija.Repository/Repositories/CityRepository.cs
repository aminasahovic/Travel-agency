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
    public interface ICityRepository
    {
        List<City> GetByName(string name);
        City GetByID(int id);

        List<City> GetByPostalCode(string name);
        List<City> GetAllCities();
        List<City> GetByCountry(Country country);

    }
    public class CityRepository : Repository<City>, ICityRepository
    {
        DbSet<City> _dbSet;
        public CityRepository(TuristickaAgencijaDbContext db) : base(db)
        {
            _dbSet = db.Set<City>();

        }

        public List<City> GetAllCities()
        {
            return _dbSet.Include(c=> c.Country).ToList();
        }

        public List<City> GetByCountry(Country country)
        {
            return _dbSet.Where(x=>x.Country== country).ToList();
        }

        public City GetByID(int id)
        {
            return _dbSet.Where(x=>x.CityID== id).ToList().FirstOrDefault();
        }

        public List<City> GetByName(string name)
        {
            return _dbSet.Where(x=>x.CityName.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<City> GetByPostalCode(string code)
        {
            return _dbSet.Where(x => x.CityPostalCode.ToLower().Contains(code.ToLower())).ToList();

        }
    }
}
