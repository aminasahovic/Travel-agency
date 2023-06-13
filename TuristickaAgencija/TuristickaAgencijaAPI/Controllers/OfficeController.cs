using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        IOfficeService officeService;
        public OfficeController(IOfficeService officeService)
        {
            this.officeService = officeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Office>>> GetAll()
        {
            return Ok(officeService.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<List<Office>>> AddOffice(OfficeAddVM office)
        {
            officeService.Add(office);
            return Ok(officeService.GetAll());
        }
        [HttpDelete]
        public async Task<ActionResult<List<Office>>> RemoveOffice(int id)
        {
            officeService.Remove(id);
            return Ok(officeService.GetAll());
        }
    }
}
