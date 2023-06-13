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
    public interface IMotelRepository
    {
        List<Motel> GetByName(string name);
        Motel GetById(int countryID);
        List<Motel> GetAll();

    }
    public class MotelRepository:Repository<Motel>, IMotelRepository
    {
        DbSet<Motel> _dbSet;

        public MotelRepository(TuristickaAgencijaDbContext db) : base(db)
        {
            _dbSet = db.Set<Motel>();
        }

        public List<Motel> GetAll()
        {
            return _dbSet.Include(x=> x.Destination).ToList();
        }

        public Motel GetById(int id)
        {
            return _dbSet.ToList().Find(x => x.AccommodationID == id);
        }

        public List<Motel> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
