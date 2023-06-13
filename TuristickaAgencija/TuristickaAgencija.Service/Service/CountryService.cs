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
    public interface ICountryService
    {
        void Add(CountryAddVM obj);

        void Remove(int id);

        List<Country> GetAll();

        List<Country> GetByName(string name);

    }
    public class CountryService : ICountryService
    {
        ICountryRepository countryRepository;
        IRepository<Country> countryReposBasic;

        public CountryService(ICountryRepository countryRepository, IRepository<Country> countryReposBasic)
        {
            this.countryRepository = countryRepository;
            this.countryReposBasic = countryReposBasic;
        }

        public void Add(CountryAddVM obj)
        {
            var newCountry = new Country()
            {
                Name = obj.Name,
                Code = obj.Code
            };
            countryReposBasic.Add(newCountry);
        }

        public List<Country> GetAll()
        {
            return (List<Country>)countryReposBasic.GetAll();
        }

        public List<Country> GetByName(string name)
        {
            return countryRepository.GetByName(name);
        }
        public List<Country> GetById(int id)
        {
            return countryRepository.GetById(id);
        }

        public void Remove(int id)
        {

            var country = countryRepository.GetById(id).FirstOrDefault();
            if(country!=null)
                countryReposBasic.Remove(country);
        }
    }
}
