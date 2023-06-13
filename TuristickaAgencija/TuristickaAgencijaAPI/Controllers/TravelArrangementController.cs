using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.TuristickaAgenija.Repositories;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelArrangementController : ControllerBase
    {
        ITravelArrangementService travelArrangmentService;
        public TravelArrangementController(ITravelArrangementService travelArrangementService)
        {
            this.travelArrangmentService = travelArrangementService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TravelArrangement>>> GetAllTravelA()
        {
            return Ok(travelArrangmentService.GetAll());
        }

       

        [HttpPost]
        public async Task<ActionResult<List<TravelArrangement>>> AddTravelArrag(TravelArrangementAddVM arr)
        {
            travelArrangmentService.Add(arr);
            return Ok(travelArrangmentService.GetAll());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TravelArrangement>>> Remove(int id)
        {
            travelArrangmentService.Remove(id);
            return Ok(travelArrangmentService.GetAll());

        }

        [HttpGet("{userid}")]
        public List<TravelArrangement> GetAllTravelAbyId(int userid)
        {
            return travelArrangmentService.GetByUserId(userid);
        }


    }
}
