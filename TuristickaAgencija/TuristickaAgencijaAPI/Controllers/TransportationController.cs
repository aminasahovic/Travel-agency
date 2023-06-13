using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportationController : ControllerBase
    {
        ITransportationService transportationService;
        public TransportationController(ITransportationService transportationService)
        {
            this.transportationService = transportationService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Transportation>>> GetAllTransportation()
        {
            return Ok(transportationService.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<List<Transportation>>> AddTransport(TransportationAddVM transport)
        {
            transportationService.Add(transport);
            return Ok(transportationService.GetAll());

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Transportation>>> RemoveTransport(int id)
        {
            transportationService.Remove(id);
            return Ok(transportationService.GetAll());

        }
    }
}
