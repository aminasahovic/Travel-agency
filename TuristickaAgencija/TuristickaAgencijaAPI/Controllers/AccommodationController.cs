using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.TuristickaAgenija.Migrations;
using Service.TuristickaAgencija.Service;
using System.Security.AccessControl;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        IAccommodationService accommodationService;
        public AccommodationController(IAccommodationService accommodationService)
        {
            this.accommodationService = accommodationService;   
        }
        [HttpGet]
        public async Task<ActionResult<List<Accommodation>>> GetAllAccommodation()
        {
            return Ok(accommodationService.getAll());
        }

        [HttpGet("getbyid/{id}")]
        public Accommodation GetById(int id)
        {
            return accommodationService.GetById(id);
        }
        [HttpPost]
        public Accommodation AddAccomodation(AccommodationAddVM accommodation)
        {
            accommodationService.Add(accommodation);
            return accommodationService.GetLast();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Accommodation>>> RemoveAccomodation(int id)
        {
            accommodationService.Remove(id);
            return Ok(accommodationService.getAll());

        }
        [HttpGet("{cityName}")]
        public async Task<ActionResult<List<Accommodation>>> GetByCityName(string cityName)
        {

            return Ok(accommodationService.GetByCity(cityName));
        }
    }
}
