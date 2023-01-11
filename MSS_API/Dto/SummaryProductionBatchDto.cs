using MSS_API.Models.WorkMonitoring;

namespace MSS_API.Dto
{
    public class SummaryProductionBatchDto
    {
        public string? ReportName { get; set; }

        public string? Description { get; set; }

        public string? ReportHeading { get; set; }

        public string? ReportFooter { get; set; }

        public DateTime? ReportDate { get; set; }

        public IEnumerable<ProductionBatch>? ProductionBatchResult { get; set; }
    }
}
