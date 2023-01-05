using MSS_API.Models.Departments;
using MSS_API.Models.EmployeeUsers;

namespace MSS_API.Interfaces
{
    public interface IHumanResourceRepository
    {
        ICollection<Department> GetDepartments();

        ICollection<EmployeeUser> GetEmployees();
    }
}
