using MSS_API.Models.EmployeeUsers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSS_API.Models.WorkMonitoring
{
    public class EmployeePerformance
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "KPI")]
        public double KPI { get; set; }

        [Display(Name = "Task Count")]
        public int TaskCount { get; set; }

        [Display(Name = "Time Logged")]
        public int TimeLogged { get; set; }

        // EmployeePerformance has One EmployeeUser (1-1 relationship)
        [ForeignKey("EmployeeUserId")]
        [Display(Name = "Employee User Id")]
        public int EmployeeUserId { get; set; }
        public EmployeeUser EmployeeUser { get; set; }
    }
}
