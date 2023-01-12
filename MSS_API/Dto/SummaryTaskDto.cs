using MSS_API.Models.WorkMonitoring;

namespace MSS_API.Dto
{
    public class SummaryTaskDto
    {
        public string? ReportName { get; set; }

        public string? Description { get; set; }

        public string? ReportHeading { get; set; }

        public string? ReportFooter { get; set; }

        public DateTime? ReportDate { get; set; }

        public IEnumerable<KanBanTask>? KanBanTaskResult { get; set; }
    }
}
