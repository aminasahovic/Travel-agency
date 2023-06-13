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
    public interface IDestinationRepository
    {
        List<Destination> GetAllDestinations();
        Destination GetById(int id);
        
        void ModifyData(Destination destination);

        void InitializeDestination(Destination destination);
    }
    public class DestinationRepository : Repository<Destination>, IDestinationRepository
    {
        DbSet<Destination> _dbSet;
        public DestinationRepository(TuristickaAgencijaDbContext db) : base(db)
        {
            _dbSet=db.Set<Destination>();
        }

        public List<Destination> GetAllDestinations()
        {
            return _dbSet.Include(c => c.City).ThenInclude(c => c.Country).ToList();
        }

        public Destination GetById(int id)
        {
            return _dbSet.Include(d => d.City)
                  .ThenInclude(c => c.Country)
                  .FirstOrDefault(d => d.DestinationID == id); ;
        }

        public void ModifyData(Destination destination)
        {
            _dbSet.Update(destination);
            
        }
        public void InitializeDestination(Destination destination)
        {
            _dbSet.Add(destination);
        }
    }
}
