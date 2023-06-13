using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }
        [HttpPost]
        public async Task<ActionResult<List<Client>>> AddClient(ClientAddVM obj)
        {
            if (clientService.Add(obj))
            {
                return Ok(clientService.GetAll());

            }
            return BadRequest("Greška!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Client>>> RemoveClient(int id)
        {
            clientService.Remove(id);
            return Ok(clientService.GetAll());
        }
        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAllClients()
        {
            return Ok(clientService.GetAll());
        }
    }

}

