using MSS_API.Models.Departments;
using MSS_API.Models.WorkMonitoring;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSS_API.Models.EmployeeUsers
{
    public class EmployeeUser
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Job Role")]
        public string JobRole { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        //Employee has One Department (1-M relationship)
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        //[SwaggerSchema(Description = "Workshop that the inventory belongs to")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // Middle level manager creates many ProductionBatches (1-M relationship)
        public ICollection<ProductionBatch> ProductionBatches { get; set; }

        // Labourer has many KanBanTasks (1-M relationship)
        public ICollection<KanBanTask> KanBanTasks { get; set; }
    }
}
