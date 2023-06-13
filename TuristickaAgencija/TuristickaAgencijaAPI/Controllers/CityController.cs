using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ICityService cityService;
        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }
        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAllCity()
        {
            return Ok(cityService.GetAll());
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<List<City>>> GetCityByName(string name)
        {
            return Ok(cityService.GetByName(name));
        }
        [HttpGet("code/{code}")]
        public async Task<ActionResult<List<Country>>> GetCityByPostalCode(string code)
        {
            return Ok(cityService.GetByPostalCode(code));
        }

        [HttpPost]
        public async Task<ActionResult<List<City>>> AddCity(CityAddVM city)
        {
            cityService.Add(city);
            return Ok(cityService.GetAll());
        }
        [HttpDelete]
        public async Task<ActionResult<List<City>>> RemoveCity(int id)
        {
            cityService.Remove(id);
            return Ok(cityService.GetAll());
        }
    }
}
