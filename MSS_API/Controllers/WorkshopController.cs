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
        public IActionResult GetAll()
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
        public IActionResult GetRecordById(int id)
        {
            if (!_workshopRepository.CheckWorkshopIsExist(id))
                return NotFound();

            var workshop = _workshopRepository.GetWorkshop(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(workshop);
        }


        [HttpGet("{id}/name")]
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateRecord([FromBody] Workshop data)
        {
            if (data == null)
                return BadRequest(ModelState);

            //var workshop = _workshopRepository.GetWorkshops().Where(w => w.Name.Trim().ToUpper() == workshopCreate.Name.Trim().ToUpper());

            //if (workshop != null)
            //{
            //    ModelState.AddModelError("", "Record already exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!_workshopRepository.CreateWorkshop(data))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateRecord([FromBody] Workshop data)
        {
            if (data == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_workshopRepository.CheckWorkshopIsExist(data.Id))
                return NotFound();

            if(!_workshopRepository.UpdateWorkshop(data))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteRecord(int id)
        {

            if (!_workshopRepository.CheckWorkshopIsExist(id))
                return NotFound();

            var data = _workshopRepository.GetWorkshop(id);

            if (data == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_workshopRepository.DeleteWorkshop(data))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        //Update by code. Only selected fields.
        [HttpPut("{id}/ChangeFactory")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateFactoryOfWorkshop(int id)
        {
            //if (data == null || !ModelState.IsValid)
            //    return BadRequest(ModelState);

            if (!_workshopRepository.CheckWorkshopIsExist(id))
                return NotFound();

            var data = _workshopRepository.GetWorkshop(id);

            if (data == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            //change factory id
            data.FactoryId = 5;

            if (!_workshopRepository.UpdateWorkshop(data))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

    }
}
