using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Repository.TuristickaAgenija.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TuristickaAgencija.Service
{

    public interface IDepartmentService
    {
        void Add(DepartmentAddVM obj);

        void Remove(int id);

        List<Department> GetAll();

        List<Department> GetByName(string name);
        List<Department> GetById(int id);
    }
    public class DepartmentService : IDepartmentService
    {
        IDepartmentRepository departmentRepository;
        IRepository<Department> departmentRepositoryBasic;

        public DepartmentService(IDepartmentRepository departmentRepository, IRepository<Department> departmentRepositoryBasic)
        {
            this.departmentRepository = departmentRepository;
            this.departmentRepositoryBasic = departmentRepositoryBasic;
        }

        public void Add(DepartmentAddVM obj)
        {
           var newDepartment= new Department()
           {
               Name= obj.Name,
               NumberOfPeople= obj.NumberOfPeople
           };
            departmentRepositoryBasic.Add(newDepartment);
        }

        public List<Department> GetAll()
        {
            return departmentRepositoryBasic.GetAll();
        }

        public List<Department> GetById(int id)
        {
            return departmentRepository.GetById(id);
        }

        public List<Department> GetByName(string name)
        {
            return departmentRepository.GetByName(name);
        }

        public void Remove(int id)
        {
            var forDelete= departmentRepository.GetById(id).FirstOrDefault();
            if(forDelete!=null)
                departmentRepositoryBasic.Remove(forDelete);
        }
    }
}
