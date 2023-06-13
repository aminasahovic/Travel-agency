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
    public interface ICounterService
    {
        void Add(CounterAddVM obj);

        void Remove(int id);

        List<Counter> GetAll();

        List<Counter> GetByName(string name);
    }
    public class CounterService : ICounterService
    {
        ICounterRepository counterRepository;
        IRepository<Counter> counterRepositoryBasic;
        public CounterService(ICounterRepository counterRepository, IRepository<Counter> counterReposBasic)
        {
            this.counterRepository=counterRepository;
            this.counterRepositoryBasic=counterReposBasic;
        }
        public void Add(CounterAddVM obj)
        {
            var newCounter= new Counter()
            {
                Name= obj.Name
            };
            counterRepositoryBasic.Add(newCounter);
        }

        public List<Counter> GetAll()
        {
            return counterRepositoryBasic.GetAll();
        }

        public List<Counter> GetByName(string name)
        {
           return counterRepository.GetByName(name);
        }

        public void Remove(int id)
        {
            var forDelete= counterRepositoryBasic.GetAll().Where(x=>x.CounterID==id).FirstOrDefault();
            if (forDelete != null)
                counterRepositoryBasic.Remove(forDelete);
        }
    }
}
