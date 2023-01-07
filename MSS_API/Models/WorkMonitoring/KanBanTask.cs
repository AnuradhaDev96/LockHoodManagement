using MSS_API.Dto.Enums;
using MSS_API.Models.EmployeeUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSS_API.Models.WorkMonitoring
{
    public class KanBanTask
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Expected Amount")]
        public int ExpectedAmount { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Status")]
        public KanBanStatus Status { get; set; }

        // KanBanTask has One ProductionBatch (1-M relationship)
        [ForeignKey("BatchId")]
        [Display(Name = "Production Batch Id")]
        public int BatchId { get; set; }
        public ProductionBatch ProductionBatch { get; set; }

        // KanBanTask has One created supervisor (1-M relationship)
        //[ForeignKey("SupervisorId")]
        //[Display(Name = "Created Supervisor")]
        //public int SupervisorId { get; set; }
        //public EmployeeUser Supervisor { get; set; }

        // KanBanTask has One assigned labourer (1-M relationship)
        [ForeignKey("LabourerId")]
        [Display(Name = "Assigned Labourer")]
        public int LabourerId { get; set; }
        public EmployeeUser Labourer { get; set; }
    }
}
