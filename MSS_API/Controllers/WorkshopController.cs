using Microsoft.AspNetCore.Mvc;
using MSS_API.Interfaces;
using MSS_API.Models.Workshops;

namespace MSS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkshopController : Controller
    {
        private readonly IWorkshopRepository _workshopRepository;

        public WorkshopController(IWorkshopRepository workshopRepository)
        {
            _workshopRepository = workshopRepository;
        }

        [HttpGet("all", Name = "GetWorkshops")]
        [ProducesResponseType(200, Type=(typeof(IEnumerable<Workshop>)))]
        public IActionResult GetWorkshops()
        {
            var workshops = _workshopRepository.GetWorkshops();
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(workshops);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = (typeof(Workshop)))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetWorkshop(int id)
        {
            if (!_workshopRepository.CheckWorkshopIsExist(id))
                return NotFound();

            var workshop = _workshopRepository.GetWorkshop(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(workshop);
        }


        [HttpGet("{id}/rating")]
        [ProducesResponseType(200, Type = (typeof(string)))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetWorkshopName(int id)
        {
            if (!_workshopRepository.CheckWorkshopIsExist(id))
                return NotFound();

            var name = _workshopRepository.GetWorkshopName(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(name);
        }


    }
}
