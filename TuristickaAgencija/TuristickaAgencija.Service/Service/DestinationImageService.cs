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
    public interface IDestinationImageService
    {
        void Add(DestinationImageAddVM obj);
        List<DestinationImage> getById(int id);

        List<DestinationImage> getall();

        List<DestinationImage> removeById(int id);

        bool removeByDestinationId(int id);

        //public void Remove(DestinationImageAddVM obj);
    }
    public class DestinationImageService : IDestinationImageService
    {
        IRepository<DestinationImage> destinationImageRepo;

        public DestinationImageService(IRepository<DestinationImage> destinationImage)
        {
            this.destinationImageRepo = destinationImage;
        }

        public void Add(DestinationImageAddVM obj)
        {
            var img = new DestinationImage
            {
                DestinationID = obj.DestinationID,
                ImageByteArray = obj.ImageBase64.parseBase64(),
            };
            destinationImageRepo.Add(img);
        }

        public List<DestinationImage> getall()
        {
            return destinationImageRepo.GetAll();
        }

        public List<DestinationImage> getById(int id)
        {
            return destinationImageRepo.GetAll().Where(x => x.DestinationID == id).ToList();
        }

        public bool removeByDestinationId(int id)
        {
            var dest = destinationImageRepo.GetAll().Where(x => x.DestinationID == id).ToList();

            if (dest != null)
            {
                foreach (var d in dest)
                {
                    destinationImageRepo.Remove(d);
                }
                return true;
            }
            return false;
        }

        public List<DestinationImage> removeById(int id)
        {
            var img = destinationImageRepo.GetAll().Where(x => x.DestinationImageID == id).FirstOrDefault();
            if (img != null)
            {
                destinationImageRepo.Remove(img);
            }
            return destinationImageRepo.GetAll();
        }

        
    }
}
