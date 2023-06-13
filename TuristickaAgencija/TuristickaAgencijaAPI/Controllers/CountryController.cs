using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryService countryService;
        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            return Ok(countryService.GetAll());
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<Country>>> GetAllCountries(string name)
        {
            return Ok(countryService.GetByName(name));
        }
        [HttpPost]
        public async Task<ActionResult<List<Country>>> AddCountry(CountryAddVM country)
        {
            countryService.Add(country);
            return Ok(countryService.GetAll());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Country>>> RemoveCountry(int id)
        {
            countryService.Remove(id);
            return Ok(countryService.GetAll());
        }
    }
}
