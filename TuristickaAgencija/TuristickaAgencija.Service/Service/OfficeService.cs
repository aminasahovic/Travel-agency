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
    public interface IOfficeService
    {
        void Add(OfficeAddVM obj);
        void Remove(int id);
        List<Office> GetAll();

        List<Office> GetByName(string name);
        List<Office> GetByDepartment(Department department);
        List<Office> GetByDepartmentID(int departmentID);


    }
    public class OfficeService : IOfficeService
    {
        IDepartmentRepository departmentRepository;
        IOfficeRepostory officeRepostory;
        IRepository<Office> repository;
        public OfficeService(IDepartmentRepository departmentRepository, IOfficeRepostory officeRepostory, IRepository<Office> repository)
        {
            this.departmentRepository = departmentRepository;
            this.officeRepostory = officeRepostory;
            this.repository = repository;
        }

        public void Add(OfficeAddVM obj)
        {
            var Department = departmentRepository.GetById(obj.DepartmentID).FirstOrDefault();
            if (Department != null)
            {
                var newOffice = new Office()
                {
                    Department = Department,
                    OfficeNumber= obj.OfficeNumber

                };
                repository.Add(newOffice);
            }
        }

        public List<Office> GetAll()
        {
            return officeRepostory.GetAll();
        }

        public List<Office> GetByDepartment(Department department)
        {
            return officeRepostory.GetByDepartment(department);
        }

        public List<Office> GetByDepartmentID(int departmentID)
        {
            return officeRepostory.GetByDepartmentID(departmentID);
        }

        public List<Office> GetByName(string name)
        {
           return officeRepostory.GetByName(name);
        }

        public void Remove(int id)
        {
            var forDelete=officeRepostory.GetById(id).FirstOrDefault();
            if (forDelete != null)
                repository.Remove(forDelete);
        }
    }
}
