using MSS_API.Models.Departments;
using MSS_API.Models.EmployeeUsers;
using MSS_API.Models.WorkMonitoring;

namespace MSS_API.Interfaces
{
    public interface IHumanResourceRepository
    {
        ICollection<Department> GetDepartments();

        ICollection<EmployeeUser> GetEmployees();

        ICollection<KanBanTask> GetAllKanBanTasks();

        EmployeeUser? GetEmployeeUser(string email);
    }
}
