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
    public interface ITravelArrangmentRepository
    {
        List<TravelArrangement> GetAllTransportation();
        TravelArrangement GetById(int id);
    }
    public class TravelArrangementRepository: Repository<TravelArrangement>,ITravelArrangmentRepository
    {
        DbSet<TravelArrangement> _dbSet;
        public TravelArrangementRepository(TuristickaAgencijaDbContext db): base(db)
        {
            _dbSet=db.Set<TravelArrangement>();
        }

        public List<TravelArrangement> GetAllTransportation()
        {
            return _dbSet.Include(c=>c.Users).Include(a=>a.Accommodation).Include(d=>d.Destination).Include(t=>t.Transportation).ToList();
        }

        public TravelArrangement? GetById(int id)
        {
            return _dbSet.Where(x => x.TravelArrangementID == id).FirstOrDefault();
        }
    }
}
