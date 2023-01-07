using Microsoft.AspNetCore.Mvc;
using MSS_API.Interfaces;
using MSS_API.Models.Departments;
using MSS_API.Models.EmployeeUsers;
using MSS_API.Models.WorkMonitoring;

namespace MSS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumanResourceController : Controller
    {
        private readonly IHumanResourceRepository _humanResourceRepository;

        public HumanResourceController(IHumanResourceRepository humanResourceRepository)
        {
            _humanResourceRepository = humanResourceRepository;
        }

        [HttpGet("Departments/all", Name = "GetDepartments")]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<Department>)))]
        public IActionResult GetAll()
        {
            var data = _humanResourceRepository.GetDepartments();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(data);
        }

        [HttpGet("Employees/GetUser/{email}")]
        [ProducesResponseType(200, Type = (typeof(EmployeeUser)))]
        public IActionResult GetUser(string email)
        {
            var data = _humanResourceRepository.GetEmployeeUser(email);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(data);
        }

        [HttpGet("KanBanTasks/all")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<KanBanTask>)))]
        public IActionResult GetAllInventoryItems()
        {

            var items = _humanResourceRepository.GetAllKanBanTasks();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items);
        }
    }
}
