using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationImageController : ControllerBase
    {
        IDestinationImageService destinationImageService;
        public DestinationImageController(IDestinationImageService destinationImageService)
        {
            this.destinationImageService = destinationImageService;
        }

        //[HttpPost]
        //public Slika AddSlika(SlikaVM slikaVM)
        //{
        //    var novaSlika = new Slika()
        //    {
        //        SobaID = slikaVM.sobaId,
        //        HotelID = slikaVM.hotelId,
        //        SlikaByteArray = slikaVM.slika.parseBase64()
        //    };
        //    slikaService.Add(novaSlika);
        //    return novaSlika;
        //}

        [HttpPost]

        public void Add(DestinationImageAddVM obj)
        {
             destinationImageService.Add(obj);
        }

        [HttpGet]
        public List<DestinationImage> GetById(int id)
        {
            return destinationImageService.getById(id);
        }

        [HttpGet("getall")]
        public List<DestinationImage> GetAll()
        {
            return destinationImageService.getall();
        }
        [HttpDelete]
        public List<DestinationImage> DeleteById(int id)
        {
            return destinationImageService.removeById(id);
        }

    }
}
