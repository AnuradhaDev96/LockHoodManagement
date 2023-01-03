using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSS_API.Dto;
using MSS_API.Interfaces;
using MSS_API.Models.Inventories;
using MSS_API.Models.Workshops;

namespace MSS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IMapper _mapper;

        public InventoryController(IInventoryRepository inventoryRepository, IWorkshopRepository workshopRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
            _workshopRepository = workshopRepository;
        }

        #region Inventory Methods
        [HttpGet("all", Name = "GetInventories")]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<Inventory>)))]
        public IActionResult GetAll()
        {
            var workshops = _inventoryRepository.GetInventories();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(workshops);
        }

        [HttpGet("InventoryWorkshop")]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<Workshop>)))]
        public IActionResult GetWorkshopListWithInventory()
        {
            var workshops = _inventoryRepository.GetWorkshopListWithSingleInventory();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(workshops);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateRecord([FromBody] InventoryDto data)
        {
            if (data == null)
                return BadRequest(ModelState);

            //var workshop = _workshopRepository.GetWorkshops().Where(w => w.Name.Trim().ToUpper() == workshopCreate.Name.Trim().ToUpper());
            //var inventoryWithWorkshopId = _inventoryRepository.GetInventories().Where
            //if (workshop != null)
            //{
            //    ModelState.AddModelError("", "Record already exists");
            //    return StatusCode(422, ModelState);
            //}

            if (!_workshopRepository.CheckWorkshopIsExist(data.WorkshopId)) 
            {
                return NotFound(@$"Workshop does not exist for id {data.WorkshopId}");
            }

            if (_inventoryRepository.CheckWorkshopAlreadyHasInventory(data.WorkshopId))
            {
                ModelState.AddModelError("", @$"Inventory already exists for workshop id {data.WorkshopId}");
                return StatusCode(422, ModelState);
            }

            var inventoryCreate = _mapper.Map<Inventory>(data);

            if (!_inventoryRepository.CreateInventory(inventoryCreate))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return StatusCode(201, "Successfully created");
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = (typeof(Inventory)))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetRecordById(int id)
        {
            if (!_inventoryRepository.CheckInventoryIsExist(id))
                return NotFound();

            var data = _inventoryRepository.GetInventory(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(data);
        }
        #endregion

        #region InventoryItems Methods
        [HttpPost("items")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult CreateItemRecord([FromBody] InventoryItemsDto data)
        {
            if (data == null)
                return BadRequest(ModelState);

            if (!_inventoryRepository.CheckInventoryIsExist(data.InventoryId))
            {
                return NotFound(@$"Inventory does not exist for id {data.InventoryId}");
            }

            var createData = _mapper.Map<InventoryItems>(data);

            if (!_inventoryRepository.CreateInventoryItem(createData))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return StatusCode(201, "Successfully created");
        }
        #endregion
    }
}
