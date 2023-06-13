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
    public interface IClientRepository
    {
        List<Client> GetByName(string name);
        List<Client> GetById(int countryID);
        List<Client> GetByAll();

    }
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        DbSet<Client> _dbSet;

        public ClientRepository(TuristickaAgencijaDbContext db): base(db)
        {
            _dbSet = db.Set<Client>();
        }

        public List<Client> GetByAll()
        {
            return _dbSet.ToList();
            
        }

        public List<Client> GetById(int countryID)
        {
            return _dbSet.Where(x=> x.UsersID== countryID).ToList();
        }

        public List<Client> GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
