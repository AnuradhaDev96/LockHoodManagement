using MSS_API.Models.WorkMonitoring;

namespace MSS_API.Interfaces
{
    public interface IReportRepository
    {
        ICollection<KanBanTask> GetKanBanTasksInNewStatus();

        ICollection<ProductionBatch> GetAllProductionBatchesSummary();
    }
}
