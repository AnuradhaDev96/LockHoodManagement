using Microsoft.AspNetCore.Mvc;
using MSS_API.Interfaces;
using MSS_API.Models.Departments;
using MSS_API.Models.EmployeeUsers;
using MSS_API.Models.WorkMonitoring;
using MSS_API.Models.Inventories;
using MSS_API.Dto;
using AutoMapper;
using MSS_API.Models.AutomatedWarehouseRequests;

namespace MSS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HumanResourceController : Controller
    {
        private readonly IHumanResourceRepository _humanResourceRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;

        public HumanResourceController(IHumanResourceRepository humanResourceRepository, IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _humanResourceRepository = humanResourceRepository;
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
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

        [HttpGet("KanBanTasks/InventoryItemsByBatch/{batchId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<InventoryItems>)))]
        public IActionResult GetInventoryItemsByProductionBatch(int batchId)
        {

            var productionBatch = _humanResourceRepository.GetProductionBatch(batchId);

            if (productionBatch == null)
                return NotFound(@$"Production Batch does not exist for id {batchId}");

            // Get workshop assigned for the batch
            var workshopId = productionBatch.WorkshopId;

            // Get inventory of the workshop
            var inventory = _inventoryRepository.GetInventoryByWorkshopId(workshopId);

            if (inventory == null)
                return NotFound(@$"Inventory does not exist for workshop id {workshopId}");

            // Get items of the inventory
            var items = _inventoryRepository.GetItemsListOfInventory(inventory.Id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(items);
        }

        [HttpPost("KanBanTasks/AllocateResource")]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<CreateAllocatedResourceForTaskResponseDto>)))]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult CreateAllocatedResourceForTask([FromBody] TaskAllocatedResourceDto data)
        {
            if (data == null)
                return BadRequest(ModelState);

            if (_humanResourceRepository.CheckAllocatedResourceIsExistForTaskWithSameItem(taskId: data.KanBanTaskId, itemId: data.InventoryItemId))
            {
                ModelState.AddModelError("", @$"Resource already exists for task id {data.KanBanTaskId}");
                return StatusCode(422, ModelState);
            }

            var itemToBeEdited = _inventoryRepository.GetInventoryItem(data.InventoryItemId);
            if (itemToBeEdited == null)
            {
                return NotFound(@$"Inventory item does not exist for item id {data.InventoryItemId}");
            }

            var createData = _mapper.Map<TaskAllocatedResource>(data);

            if (!_humanResourceRepository.CreateAllocatedResourceForTask(createData))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            // reduce quantity in inventory item table
            var previousAvailableAmount = itemToBeEdited.AvailableQuantity;
            itemToBeEdited.AvailableQuantity = previousAvailableAmount - data.AllocatedAmount;

            if (itemToBeEdited.AvailableQuantity < 0) {
                itemToBeEdited.AvailableQuantity = 0;
            }

            if (!_inventoryRepository.ReduceAmountInInventoryItems(itemToBeEdited))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            // Compated the available quantity with alert margin and create automated request
            bool isAutomatedRequestCreated = false;
            if (itemToBeEdited.AvailableQuantity <= itemToBeEdited.AlertMargin)
            {
                AutomatedWarehouseRequest request = new AutomatedWarehouseRequest(createdOn: DateTime.Now, inventoryId: itemToBeEdited.InventoryId);
                if (!_inventoryRepository.CreateAutomatedInventoryRequest(request))
                {
                    ModelState.AddModelError("", "Something went wrong while create request");
                    return StatusCode(500, ModelState);
                }
                isAutomatedRequestCreated = true;
            }

            CreateAllocatedResourceForTaskResponseDto response = new();
            response.isResourceAllocatedToTask = true;
            response.isAutomatedInventoryRequestCreated = isAutomatedRequestCreated;

            return Ok(response);
        }

        [HttpGet("KanBanTasks/AllocateResource/{taskId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<TaskAllocatedResource>)))]
        public IActionResult GetAllocatedResourcesByTask(int taskId)
        {
            var allocatedResources = _humanResourceRepository.GetAllocatedResourcesByTaskId(taskId);
                        
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(allocatedResources);
        }
        
        [HttpGet("ProductionBatches")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = (typeof(IEnumerable<ProductionBatch>)))]
        public IActionResult GetAllProductionBatches()
        {
            var data = _humanResourceRepository.GetAllProductionBatches();
                        
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(data);
        }

        [HttpPut("ProductionBatches/UpdateTestInformation")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateTestInformationOfBatch([FromBody] UpdateTestInfoOfProductionBatchDto data)
        {
            if (data == null || !ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_humanResourceRepository.CheckProductionBatchIsExist(data.Id))
                return NotFound();

            if (data.TestedAmount < data.PassedAmount)
            {
                ModelState.AddModelError("", "Tested amount should be greater than passed amount");
                return StatusCode(422, ModelState);
            }            

            var batchToBeEdited = _humanResourceRepository.GetProductionBatch(data.Id);
            batchToBeEdited.TestedAmount = data.TestedAmount;
            batchToBeEdited.PassedAmount = data.PassedAmount;            

            if (!_humanResourceRepository.UpdateTestInformationByBatchId(batchToBeEdited))
            {
                ModelState.AddModelError("", "Something went wrong while updating test information");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
