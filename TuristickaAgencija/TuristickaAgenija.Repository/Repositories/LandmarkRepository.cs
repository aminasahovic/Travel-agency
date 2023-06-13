using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.EntityFrameworkCore;
using Repository.TuristickaAgenija.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgenija.Repository;

namespace Repository.TuristickaAgenija.Repositories
{
    public interface ILandmarkRepository
    {
        List<Landmark> GetAllLandmarks();
        List<Landmark> LandmarkGetById(int id);
        List<Landmark> GetLandmarkByCity(City city);
        List<Landmark> GetLandmarkByCityId(int id);
        
    }
    public class LandmarkRepository : Repository<Landmark>, ILandmarkRepository
    {
        DbSet<Landmark> _dbSet;

        public LandmarkRepository(TuristickaAgencijaDbContext db) : base(db)
        {
            _dbSet= db.Set<Landmark>(); 
        }

        public List<Landmark> GetAllLandmarks()
        {
            return _dbSet.Include(s => s.City).Include(s => s.City.Country).ToList();
        }

        public List<Landmark> GetLandmarkByCity(City city)
        {
            return _dbSet.Include(c=>c.City).Where(l=>l.City==city).ToList();
        }

        public List<Landmark> GetLandmarkByCityId(int id)
        {
            return _dbSet.Include(c => c.City).Where(l => l.City.CityID == id).ToList();

        }

        public List<Landmark> LandmarkGetById(int id)
        {
            return _dbSet.Include(c=>c.City).Where(l=> l.LandmarkID== id).ToList();
        }
    }
}
