using Microsoft.AspNetCore.Mvc;
using MSS_API.Interfaces;
using MSS_API.Models.Departments;

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
    }
}
