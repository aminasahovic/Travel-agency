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
    public interface ITransportationRepository
    {
        List<Transportation> GetAllTransportation();
        Transportation GetById(int id);
    }
    public class TransportationRepository : Repository<Transportation>, ITransportationRepository
    {
        DbSet<Transportation> _dbSet;
        public TransportationRepository(TuristickaAgencijaDbContext db) : base(db)
        {
            _dbSet = db.Set<Transportation>();
        }
        public List<Transportation> GetAllTransportation()
        {
            return _dbSet.ToList();
        }

        public Transportation? GetById(int id)
        {
            return _dbSet.Where(x => x.TransportationId == id).FirstOrDefault();
        }
    }
}
