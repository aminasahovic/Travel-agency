using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgenija.Repository;

namespace Repository.TuristickaAgenija.Repositories
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity obj);
        void Remove(TEntity obj);
        void Update(TEntity obj);
        IEnumerable<TEntity> GetAllEnum();
        List<TEntity> GetAll();

    }
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public TuristickaAgencijaDbContext dbContext;
        DbSet<TEntity> dbSet;

        public Repository(TuristickaAgencijaDbContext db)
        {
            dbContext = db;
            dbSet = dbContext.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            dbSet.Add(obj);
            dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsEnumerable();
        }

        public IEnumerable<TEntity> GetAllEnum()
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity obj)
        {
            dbSet.Remove(obj);
            dbContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            dbContext.Entry(obj).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        List<TEntity> IRepository<TEntity>.GetAll()
        {
            return dbSet.ToList(); 
        }
    }
}
