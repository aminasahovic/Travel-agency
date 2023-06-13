using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Repository.TuristickaAgenija.Repositories;
using Service.TuristickaAgencija.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TuristickaAgencija.Service
{
    public interface IAccommodationImage
    {
        void Add(AccommodationImageAddVM obj);
        List<AccommodationImage> getById(int id);

        List<AccommodationImage> getall();

        List<AccommodationImage> removeById(int id);

    }
    public class AccommodationImageService : IAccommodationImage
    {
        IRepository<AccommodationImage> accomodationImageRepo;
        IAccommodationRepositroy accommodationRepository ;

        public AccommodationImageService(IRepository<AccommodationImage> accomodationImageRepo, IAccommodationRepositroy accommodationRepository)
        {
            this.accomodationImageRepo = accomodationImageRepo;
            this.accommodationRepository = accommodationRepository;
        }

        public void Add(AccommodationImageAddVM obj)
        {
            var accomodation = accommodationRepository.GetById(obj.AccommodationID);
            var img = new AccommodationImage()
            {
                AccomodationID = obj.AccommodationID,
                ImageByteArray = obj.ImageBase64.parseBase64(),
                Accommodation = accomodation
            };
            accomodationImageRepo.Add(img);
        }

        public List<AccommodationImage> getall()
        {
            return accomodationImageRepo.GetAll();
        }

        public List<AccommodationImage> getById(int id)
        {
            return accomodationImageRepo.GetAll().Where(x => x.AccomodationID == id).ToList();
        }

        public List<AccommodationImage> removeById(int id)
        {
            var img = accomodationImageRepo.GetAll().Where(x => x.AccomodationID == id).FirstOrDefault();
            if (img != null)
            {
                accomodationImageRepo.Remove(img);
            }
            return accomodationImageRepo.GetAll();
        }
    }
}
