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
    public interface IOfficeRepostory
    {
        List<Office> GetByName(string name);
        List<Office> GetById(int id);
        List<Office> GetByDepartment(Department department);
        List<Office> GetByDepartmentID(int departmentID);
        List<Office> GetAll();



    }
    public class OfficeRepository : Repository<Office>, IOfficeRepostory
    {
        DbSet<Office> _dbSet;
        public OfficeRepository(TuristickaAgencijaDbContext db) : base(db)
        {
            _dbSet=db.Set<Office>();
        }

        public List<Office> GetByDepartment(Department department)
        {
            return _dbSet.Where(x=>x.Department==department).ToList();
        }

        public List<Office> GetByDepartmentID(int departmentID)
        {
            return _dbSet.Include(d=>d.Department).Where(x => x.Department.DepartmentID == departmentID).ToList();

        }

        public List<Office> GetById(int id)
        {
           return _dbSet.Include(d => d.Department).Where(x=>x.OfficeID==id).ToList();
        }

        public List<Office> GetByName(string name)
        {
           return _dbSet.Include(d => d.Department).Where(x=>x.OfficeNumber==name).ToList();
        }

        List<Office> IOfficeRepostory.GetAll()
        {
            return _dbSet.Include(d=>d.Department).ToList();
        }
    }
}
