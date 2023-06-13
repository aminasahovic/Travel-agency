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
    public interface ICountryRepository
    {
        List<Country> GetByName(string name);
        List<Country> GetById(int countryID);

    }
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        DbSet<Country> _dbSet;
        public CountryRepository(TuristickaAgencijaDbContext db): base(db)
        {
            _dbSet=db.Set<Country>();
        }

        public List<Country> GetById(int countryID)
        {
            return _dbSet.Where(x => x.CountryID==countryID).ToList();

        }

        public List<Country> GetByName(string name)
        {
            return _dbSet.Where(x=>x.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public void RemoveCounty(int countryID)
        {
            _dbSet.Where(x=> x.CountryID== countryID);
        }

    }
}
