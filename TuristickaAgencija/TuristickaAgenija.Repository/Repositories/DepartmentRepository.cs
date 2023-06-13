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
    public interface IDepartmentRepository
    {
        List<Department> GetByName(string name);
        List<Department> GetById(int departmentID);
    }
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        DbSet<Department> _dbSet;
        public DepartmentRepository(TuristickaAgencijaDbContext db) : base(db)
        {
            _dbSet=db.Set<Department>();
        }

        public List<Department> GetById(int departmentID)
        {
           return _dbSet.Where(x=>x.DepartmentID==departmentID).ToList();
        }

        public List<Department> GetByName(string name)
        {
            return _dbSet.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
