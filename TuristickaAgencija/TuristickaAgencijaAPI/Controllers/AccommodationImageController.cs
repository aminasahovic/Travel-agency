using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationImageController : ControllerBase
    {
        IAccommodationImage accommodationImageService;
        public AccommodationImageController(IAccommodationImage accommodation)
        {
            this.accommodationImageService = accommodation;
        }

        [HttpPost]

        public void Add(AccommodationImageAddVM obj)
        {
            accommodationImageService.Add(obj);
        }

        [HttpGet]
        public List<AccommodationImage> GetById(int id)
        {
            return accommodationImageService.getById(id);
        }

        [HttpGet("getall")]
        public List<AccommodationImage> GetAll()
        {
            return accommodationImageService.getall();
        }
        [HttpDelete]
        public List<AccommodationImage> DeleteById(int id)
        {
            return accommodationImageService.removeById(id);
        }

    }
}
