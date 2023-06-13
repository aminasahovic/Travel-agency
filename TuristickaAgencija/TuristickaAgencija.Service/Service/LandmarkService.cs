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
    public interface ILandmarkService
    {
        void Add(LandmarkAddVM obj);
        List<Landmark> GetAll();
        void Remove(int id);

    }
    public class LandmarkService : ILandmarkService
    {
        ILandmarkRepository landmarkRepository;
        ICityRepository cityRepository;

        IRepository<Landmark> landmarkReposBasic;

        public LandmarkService(IRepository<Landmark> landmarkReposBasic, ILandmarkRepository landmarkRepository, ICityRepository cityRepository)
        {
            this.landmarkRepository = landmarkRepository;
            this.landmarkReposBasic = landmarkReposBasic;
            this.cityRepository = cityRepository;
        }

        public void Add(LandmarkAddVM obj)
        {
            var getCity = cityRepository.GetByID(obj.CityId);
            var landmark = new Landmark()
            {
                City = getCity,
                Name = obj.Name,
                Price = obj.Price
            };
            landmarkReposBasic.Add(landmark);
        }

        public List<Landmark> GetAll()
        {
            return landmarkRepository.GetAllLandmarks();
        }

        public void Remove(int id)
        {
            var landmark = landmarkRepository.LandmarkGetById(id).FirstOrDefault();

            if (landmark != null)
                landmarkReposBasic.Remove(landmark);
        }
    }
}
