using MSS_API.Models.Departments;
using MSS_API.Models.EmployeeUsers;
using MSS_API.Models.Inventories;
using MSS_API.Models.WorkMonitoring;

namespace MSS_API.Interfaces
{
    public interface IHumanResourceRepository
    {
        ICollection<Department> GetDepartments();

        ICollection<EmployeeUser> GetEmployees();

        ICollection<KanBanTask> GetAllKanBanTasks();

        ICollection<TaskAllocatedResource> GetAllocatedResourcesByTaskId(int taskId);

        bool CheckAllocatedResourceIsExistForTaskWithSameItem(int taskId, int itemId);

        EmployeeUser? GetEmployeeUser(string email);

        ProductionBatch? GetProductionBatch(int id);

        bool CreateAllocatedResourceForTask(TaskAllocatedResource data);        

        bool Save();
    }
}
