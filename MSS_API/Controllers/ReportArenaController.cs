using Microsoft.AspNetCore.Mvc;
using MSS_API.Dto;
using MSS_API.Interfaces;

namespace MSS_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportArenaController : Controller
    {
        private readonly IReportRepository _reportRepository;

        public ReportArenaController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet("KanBanTasksSummary/NewTasks")]
        [ProducesResponseType(200, Type = (typeof(SummaryTaskDto)))]
        [ProducesResponseType(500)]
        public IActionResult GetNewTasksReport()
        {
            var taskResult = _reportRepository.GetKanBanTasksInNewStatus();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            SummaryTaskDto summary = new();
            summary.ReportName = "KanBan Tasks in Status NEW Report";
            summary.Description = "The summary of all KanBan tasks which are still in NEW status. These tasks are not yet intitated by the workshop labourers";
            summary.ReportDate = DateTime.Now;
            summary.ReportHeading = "Lock Hood Management Company Owned Document";
            summary.ReportFooter = "Created by Lock Hood Management Portal.";
            summary.KanBanTaskResult = taskResult;

            return Ok(summary);
        }

        [HttpGet("ProductionBatchSummary/Overview")]
        [ProducesResponseType(200, Type = (typeof(SummaryProductionBatchDto)))]
        [ProducesResponseType(500)]
        public IActionResult GetAllProductionBatchesReport()
        {
            var result = _reportRepository.GetAllProductionBatchesSummary();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            SummaryProductionBatchDto summary = new();
            summary.ReportName = "Production Batch Report";
            summary.Description = "The summary of all Production Batches are here. Go to schedule task page to evaluate the progresses";
            summary.ReportDate = DateTime.Now;
            summary.ReportHeading = "Lock Hood Management Company Owned Document";
            summary.ReportFooter = "Created by Lock Hood Management Portal.";
            summary.ProductionBatchResult = result;

            return Ok(summary);
        }
    }
}
