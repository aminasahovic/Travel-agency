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
    public interface ICityService
    {
        void Add(CityAddVM obj);
        void Remove(int id);
        List<City> GetAll();
        List<City> GetByName(string name);
        List<City> GetByPostalCode(string name);
        List<City> GetByCountry(Country country);

    }
    public class CityService : ICityService
    {
        ICityRepository cityRepository;
        ICountryRepository countryRepository;

        IRepository<City> cityReposBasic;
        public CityService(ICityRepository cityRepository, IRepository<City> cityReposBasic, ICountryRepository countryRepository)
        {
            this.cityRepository = cityRepository;
            this.cityReposBasic = cityReposBasic;
            this.countryRepository = countryRepository;
        }

        public void Add(CityAddVM obj)
        {
            var getCountry=countryRepository.GetById(obj.CountryId).FirstOrDefault();
            var newCity = new City()
            {
                CityName = obj.CityName,
                CityPostalCode = obj.CityPostalCode,
                Country = getCountry
            };
            cityReposBasic.Add(newCity);
        }

        public List<City> GetAll()
        {
            return cityRepository.GetAllCities();

        }

        public List<City> GetByCountry(Country country)
        {
           return cityRepository.GetByCountry(country);
        }

        public List<City> GetByName(string name)
        {
            return cityRepository.GetByName(name).ToList();
        }

        public List<City> GetByPostalCode(string code)
        {
           return cityRepository.GetByPostalCode(code).ToList();
        }

        public void Remove(int id)
        {
            var toDelete=cityRepository.GetByID(id);
            cityReposBasic.Remove(toDelete);
        }
    }
}
