using MSS_API.Models.EmployeeUsers;
using MSS_API.Models.Workshops;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSS_API.Models.WorkMonitoring
{
    public class ProductionBatch
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [Display(Name = "Deadline")]
        public DateTime Deadline { get; set; }

        // ProductionBatch has One Department (1-M relationship)
        [ForeignKey("Workshop")]
        [Display(Name = "Workshop")]
        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }

        // ProductionBatch has One Middle Level Manager (1-M relationship)
        [ForeignKey("EmployeeUser")]
        [Display(Name = "Created Manager")]
        public int CreatedManagerId { get; set; }
        public EmployeeUser CreatedManager { get; set; }

        public ICollection<KanBanTask> KanBanTasks { get; set; }
    }
}
