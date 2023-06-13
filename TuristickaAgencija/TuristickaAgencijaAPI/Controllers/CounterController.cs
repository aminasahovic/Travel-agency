using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterController : ControllerBase
    {
        ICounterService counterService;
        public CounterController(ICounterService counterService)
        {
            this.counterService = counterService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Counter>>> GetAllCounters()
        {
            return Ok(counterService.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<List<Counter>>> AddCountry(CounterAddVM counter)
        {
            counterService.Add(counter);
            return Ok(counterService.GetAll());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Counter>>> RemoveCouner(int id)
        {
            counterService.Remove(id);
            return Ok(counterService.GetAll());
        }
    }
}
