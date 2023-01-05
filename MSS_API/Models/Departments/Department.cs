using MSS_API.Dto.Enums;
using MSS_API.Models.EmployeeUsers;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MSS_API.Models.Departments
{
    public class Department
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        // type of Enum:DepartmentType
        [SwaggerSchema(Description = "Department Type")]
        public DepartmentType DepartmentType { get; set; }

        //Department has Many Employees (1-M relationship)
        [Display(Name = "Employee Users")]
        [SwaggerSchema(Description = "Employees of department")]
        public ICollection<EmployeeUser> EmployeeUsers { get; set; }
    }
}
