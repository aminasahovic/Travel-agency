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
    public interface ITravelArrangementService
    {
        void Add(TravelArrangementAddVM t);
        void Remove(int id);
        List<TravelArrangement> GetAll();
        List<TravelArrangement> GetByUserId(int userid);

        TravelArrangement GetById(int id);
    }
    public class TravelArrangementService : ITravelArrangementService
    {
        ITravelArrangmentRepository travelArrangmentRepository;
        IRepository<TravelArrangement> basicRepo;
        IUsersRepository usersRepository;
        IDestinationRepository destinationRepository;
        ITransportationRepository transportationRepository;
        IAccommodationRepositroy accommodationRepository;
        public TravelArrangementService(ITravelArrangmentRepository travelArrangmentRepository, IRepository<TravelArrangement> basicRepo, IUsersRepository usersRepository, IDestinationRepository destinationRepository, ITransportationRepository transportationRepository, IAccommodationRepositroy accommodationRepositroy)
        {
            this.travelArrangmentRepository = travelArrangmentRepository;
            this.basicRepo = basicRepo;
            this.usersRepository = usersRepository;
            this.destinationRepository = destinationRepository;
            this.transportationRepository = transportationRepository;
            this.accommodationRepository= accommodationRepositroy;
        }

        public void Add(TravelArrangementAddVM t)
        {
            var getUser = usersRepository.GetById(t.UserID);
            var getDestination = destinationRepository.GetById(t.DestinationID);
            var getTransport = transportationRepository.GetById(t.TrnsportID);
            var getAccommodation = accommodationRepository.GetById(t.AccomodationID);
            var newArrangmnet = new TravelArrangement()
            {
                Destination = getDestination,
                Users = getUser,
                NumberOfPerson = t.NumberOfPerson,
                Transportation = getTransport,
                Accommodation = getAccommodation,
                Price = getDestination.Price+getAccommodation.Price,
                IsAccepted = false,
                DepartureTime= t.DepartureTime,
                ArrivalTime= t.ArrivalTime,
            };
            basicRepo.Add(newArrangmnet);
        }

        public List<TravelArrangement> GetAll()
        {
            return travelArrangmentRepository.GetAllTransportation();
        }

        public TravelArrangement GetById(int id)
        {
            return travelArrangmentRepository.GetById(id);
        }

        public List<TravelArrangement> GetByUserId(int userid)
        {
            return travelArrangmentRepository.GetAllTransportation().Where(x => x.Users.UsersID == userid).Reverse().ToList();
        }

        public void Remove(int id)
        {
            var forDelete = travelArrangmentRepository.GetById(id);
            basicRepo.Remove(forDelete);
        }
    }
}
