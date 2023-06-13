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
    public interface IDestinationService
    {
        List<Destination> GetAll();
        void Add(DestinationAddVM destination);
        bool Remove(int id);
        void Update(DestinationAddVM destination);
        Destination getLast();
    }
    public class DestinationService : IDestinationService
    {
        ICityRepository cityRepository;
        ICountryRepository countryRepository;
        IDestinationImageService destinationImageService;

        IRepository<Destination> destinationReposBasic;
        IDestinationRepository destinationRepository;
        IAccommodationRepositroy accommodationRepositroy;

        public DestinationService(IRepository<Destination> destinationReposBasic, ICountryRepository countryRepository, IDestinationRepository destinationRepository, IDestinationImageService destinationImageService, ICityRepository cityRepository, IAccommodationRepositroy accommodationRepositroy)
        {
            this.destinationReposBasic = destinationReposBasic;
            this.destinationRepository = destinationRepository;
            this.cityRepository = cityRepository;
            this.accommodationRepositroy = accommodationRepositroy;
            this.destinationImageService = destinationImageService;
            this.countryRepository= countryRepository;
        }

        public void Add(DestinationAddVM destination)
        {
            var getCity = cityRepository.GetByID(destination.CityId);

            var newDestination = new Destination()
            {
                Name = destination.Name,
                Describe = destination.Describe,
                City = getCity,
                Price = destination.Price,
                Rate = destination.Rate,
            };
            destinationReposBasic.Add(newDestination);
        }

        public List<Destination> GetAll()
        {
            return destinationRepository.GetAllDestinations().Where(x => x.Describe != "useradded").ToList(); ;
        }

        public Destination getLast()
        {
            return destinationReposBasic.GetAll().LastOrDefault();
        }

        public bool Remove(int id)
        {
            var obj = destinationRepository.GetById(id);
            if (!accommodationRepositroy.ifExistDestination(id) && obj != null)
            {
                destinationReposBasic.Remove(obj);
                destinationImageService.removeByDestinationId(id);

                return true;
            }
            return false;
        }

        public void Update(DestinationAddVM destination)
        {
            Destination newDest = destinationRepository.GetById(destination.DestinationID);
            var getCity = cityRepository.GetByID(destination.CityId);

            if (newDest != null)
            {
                newDest.Describe = destination.Describe;
                newDest.Name = destination.Name;
                newDest.Rate = destination.Rate;
                newDest.Price = destination.Price;
                newDest.City = getCity;

                destinationReposBasic.Update(newDest);

            }
        }
    }
}
