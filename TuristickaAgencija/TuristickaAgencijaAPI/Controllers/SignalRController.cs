using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Service.TuristickaAgencija.Service;
using Web.TuristickaAgencija.HubConfig;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : ControllerBase
    {
        ICityService cityService;
        private readonly IHubContext<MyHub> hubContext;
        public SignalRController(ICityService cityService, IHubContext<MyHub> hubContext)
        {
            this.cityService = cityService;
            this.hubContext = hubContext;
        }
        [HttpGet]
        public async Task<ActionResult> PosaljiVrijeme()
        {
            string p = "Trenutno vrijeme" + DateTime.Now;
           await hubContext.Clients.All.SendAsync("slanje_poruke1", p);
            return Ok();

        }
        [HttpGet("sendMess")]
        public async Task<ActionResult> PosaljiPoruku(string p)
        {
            await hubContext.Clients.All.SendAsync("slanje_poruke2", p);
            return Ok();

        }
    }
}
