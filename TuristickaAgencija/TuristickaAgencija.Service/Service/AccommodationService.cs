using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Repository.TuristickaAgenija.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Service.TuristickaAgencija.Service
{
    public interface IAccommodationService
    {
        List<Accommodation> getAll();
        void Add(AccommodationAddVM accommodation);
        void Remove(int id);
        Accommodation GetLast();
        Accommodation GetById(int id);

        List<Accommodation> GetByCity(string city);

    }
    public class AccommodationService:IAccommodationService
    {
        IRepository<Accommodation> accommodationReposBasic;
        IAccommodationRepositroy accommodationRepository ;
        IDestinationRepository destinationRepository;
        ICityRepository cityRepository;
        public AccommodationService(IRepository<Accommodation> accommodationReposBasic, IAccommodationRepositroy accommodationRepository, IDestinationRepository destinationRepository, ICityRepository cityRepository)
        {
            this.accommodationReposBasic= accommodationReposBasic;
            this.accommodationRepository= accommodationRepository;
            this.destinationRepository= destinationRepository;
            this.cityRepository= cityRepository;

        }

        public void Add(AccommodationAddVM accommodation)
        {
            var destination = destinationRepository.GetById(accommodation.DestinationID);
            var ciyt=cityRepository.GetByID(accommodation.CityID);
            var newAccommodation = new Accommodation()
            {
                Name = accommodation.Name,
                NumberOfRooms = accommodation.NumberOfRooms,
                Pass = accommodation.Pass,
                Destination = destination,
                Price = accommodation.Price,
                City = ciyt

            };
            accommodationReposBasic.Add(newAccommodation);
        }

        public List<Accommodation> getAll()
        {
            return accommodationRepository.GetAllAccommodation();
        }

        public List<Accommodation> GetByCity(string city)
        {
           return accommodationRepository.GetByCity(city);
        }

        public Accommodation? GetById(int id)
        {
            return accommodationRepository.GetAllAccommodation().Where(x => x.AccommodationID == id).FirstOrDefault();
        }

        public Accommodation? GetLast()
        {
            return accommodationReposBasic.GetAll().LastOrDefault();
        }

        public void Remove(int id)
        {
            var obj = accommodationRepository.GetById(id);
            accommodationReposBasic.Remove(obj);
        }
    }
}
