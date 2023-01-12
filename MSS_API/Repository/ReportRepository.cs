using MSS_API.Data;
using MSS_API.Dto.Enums;
using MSS_API.Interfaces;
using MSS_API.Models.WorkMonitoring;

namespace MSS_API.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly DataContext _context;

        public ReportRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<KanBanTask> GetKanBanTasksInNewStatus()
        {
            return _context.KanBanTasks.Where(k => k.Status == KanBanStatus.New).OrderBy(x => x.Id).ToList();
        }

        public ICollection<ProductionBatch> GetAllProductionBatchesSummary()
        {
            return _context.ProductionBatches.OrderBy(w => w.Id).ToList(); 
        }
    }
}
