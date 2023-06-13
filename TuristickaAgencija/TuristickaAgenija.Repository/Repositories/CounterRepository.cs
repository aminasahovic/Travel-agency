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
    public interface ICounterRepository
    {
        List<Counter> GetByName(string name);
        List<Counter> GetById(int counterID);

    }
    public class CounterRepository : Repository<Counter>, ICounterRepository
    {
        DbSet<Counter> _dbSet;
        public CounterRepository(TuristickaAgencijaDbContext db):base(db)
        {
            _dbSet=db.Set<Counter>();
        }
        public List<Counter> GetById(int counterID)
        {
           return _dbSet.Where(x=>x.CounterID==counterID).ToList();
        }

        public List<Counter> GetByName(string name)
        {
            return _dbSet.Where(x=> x.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
