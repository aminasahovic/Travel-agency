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
    public interface IMotelService
    {
        void Add(MotelAddVM obj);

        void Remove(int id);

        List<Motel> GetAll();

    }
    public class MotelService : IMotelService
    {

        IMotelRepository motelRepository;
        IRepository<Motel> motelReposBasic;
        IDestinationRepository destinationRepository;

        public MotelService(IMotelRepository motelRepository, IRepository<Motel> motelReposBasic, IDestinationRepository destinationRepository)
        {
            this.motelRepository = motelRepository;
            this.motelReposBasic = motelReposBasic;
            this.destinationRepository = destinationRepository;
        }

        public void Add(MotelAddVM obj)
        {
            var destination = destinationRepository.GetAllDestinations().Find(x => x.DestinationID == obj.DestinationID);

            var newMotel = new Motel()
            {
                PetFriendly = obj.PetFriendly,
                Destination = destination,
                Name = obj.Name,
                NumberOfRooms = obj.NumberOfRooms,
                Parking = obj.Parking,
                Pass = obj.Pass,
                Price = obj.Price,
            };
            motelReposBasic.Add(newMotel);


        }
        public List<Motel> GetAll()
        {
            return motelRepository.GetAll();
        }

        public void Remove(int id)
        {
            var motel= motelRepository.GetById(id);

            if (motel != null)
                motelReposBasic.Remove(motel);

        }
    }
}
