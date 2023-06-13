using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandmarkController : ControllerBase
    {
        ILandmarkService landmarkService;
        public LandmarkController(ILandmarkService landmarkService)
        {
            this.landmarkService = landmarkService;
        }

        [HttpPost]
        public async Task<ActionResult<List<Landmark>>> Add(LandmarkAddVM landmark)
        {
            landmarkService.Add(landmark);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<Landmark>>> GetAllLandmark()
        {
            return Ok(landmarkService.GetAll());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Country>>> Remove(int id)
        {
            landmarkService.Remove(id);
            return Ok(landmarkService.GetAll());
        }

    }
}
