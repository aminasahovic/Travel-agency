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
    public interface ITransportationService
    {
        void Add(TransportationAddVM t);
        void Remove(int id);
        List<Transportation> GetAll();
        Transportation GetById(int id);
    }
    public class TransportationService : ITransportationService
    {
        ITransportationRepository transportationRepository;
        IRepository<Transportation> basicRepo;
        public TransportationService(ITransportationRepository transportationRepository, IRepository<Transportation> basic)
        {
            this.transportationRepository = transportationRepository;
            this.basicRepo = basic;
        }
        public void Add(TransportationAddVM transport)
        {
            var newTransport = new Transportation()
            {
                Class = transport.Class,
                Name = transport.Name,
                Price = transport.Price
            };
            basicRepo.Add(newTransport);
        }

        public List<Transportation> GetAll()
        {
            return transportationRepository.GetAllTransportation();
        }

        public Transportation GetById(int id)
        {
            return transportationRepository.GetById(id);
        }

        public void Remove(int id)
        {
            var delete = transportationRepository.GetById(id);
            basicRepo.Remove(delete);
        }
    }
}
