using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.TuristickaAgenija.Migrations;
using Service.TuristickaAgencija.Helpers;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        IDestinationService destinationService;
        IUsersService usersService;
        private readonly IEmailService _emailService;

        public DestinationController(IDestinationService destinationService, IUsersService usersService, IEmailService emailService)
        {
            this.destinationService = destinationService;
            this.usersService = usersService;
            _emailService = emailService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Destination>>> GetAllDestination()
        {
            return Ok(destinationService.GetAll());
        }
        [HttpPost]
        public Destination AddDestination(DestinationAddVM destination)
        {
            destinationService.Add(destination);
            for (int i = 0; i < usersService.GetAll().Count(); i++)
            {
                if (usersService.GetAll()[i].IsEmailAccepted == true)
                {
                    var email = usersService.GetAll()[i].Email;
                    var user = usersService.GetAll()[i];
                    var emailModel = new Email(email, "SkyTravel", EmailBody.EmailStringBody(email, "", user.FirsName + " " + user.LastName, 4, destination.Name, destination.Price));
                    _emailService.SendEmail(emailModel, 4);
                }
            }
            return destinationService.getLast();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Destination>>> RemoveDestination(int id)
        {


            if (destinationService.Remove(id))
            {
                return Ok(destinationService.GetAll());

            }
            return BadRequest("Provjerite da li se ova destinacije negdje koristi ili možda uopšte ne postoji");

        }

        [HttpPost("Update")]
        public async Task<ActionResult<List<Destination>>> UpdateDestination(DestinationAddVM destination)
        {

            destinationService.Update(destination);

            for (int i = 0; i < usersService.GetAll().Count(); i++)
            {
                if (usersService.GetAll()[i].IsEmailAccepted == true)
                {
                    var email = usersService.GetAll()[i].Email;
                    var user = usersService.GetAll()[i];
                    var emailModel = new Email(email, "SkyTravel", EmailBody.EmailStringBody(email, "", user.FirsName + " " + user.LastName, 4, destination.Name, destination.Price));
                    _emailService.SendEmail(emailModel, 4);
                }
            }
            return Ok(destinationService.GetAll());

        }
        [HttpDelete("DeleteDestination/{id}")]
        public async Task<ActionResult<List<Destination>>> DeleteDestination(int id)
        {
            destinationService.Remove(id);
            return Ok(destinationService.GetAll());
        }


    }
}
