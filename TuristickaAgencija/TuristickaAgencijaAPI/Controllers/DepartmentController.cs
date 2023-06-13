using Core.TuristickaAgencija.Models;
using Core.TuristickaAgencija.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.TuristickaAgencija.Service;

namespace Web.TuristickaAgencija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAllDepartment()
        {
            return Ok(departmentService.GetAll());
        }
        [HttpPost]
        public async Task<ActionResult<List<Department>>> AddDepartment(DepartmentAddVM department)
        {
            departmentService.Add(department);
            return Ok(departmentService.GetAll());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Department>>> RemoveDepartment(int id)
        {
            departmentService.Remove(id);
            return Ok(departmentService.GetAll());
        }
    }
}
