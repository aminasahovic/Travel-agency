using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotelController : ControllerBase
    {
        IMotelService motelService;

        public MotelController(IMotelService motelService)
        {
            this.motelService = motelService;
        }
        [HttpPost]
        public async Task<ActionResult<List<Motel>>> AddMotel(MotelAddVM obj)
        {
            if(obj != null)
            {
                motelService.Add(obj);
                return Ok(motelService.GetAll());
            }
            else
            {
                return BadRequest("Objekat je null");
            }
           
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Motel>>> RemoveMotel(int id)
        {
            motelService.Remove(id);
            return Ok(motelService.GetAll());
        }
        [HttpGet]
        public async Task<ActionResult<List<Motel>>> GetAllMotels()
        {
            return Ok(motelService.GetAll());
        }
    }
}
