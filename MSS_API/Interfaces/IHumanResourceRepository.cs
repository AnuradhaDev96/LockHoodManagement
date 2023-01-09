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

        ICollection<ProductionBatch> GetAllProductionBatches();

        bool CheckAllocatedResourceIsExistForTaskWithSameItem(int taskId, int itemId);

        bool CheckProductionBatchIsExist(int batchId);

        EmployeeUser? GetEmployeeUser(string email);

        ProductionBatch? GetProductionBatch(int id);

        ProductionBatch? GetOEECalculationResult(int batchId, int workshopId);

        bool CreateAllocatedResourceForTask(TaskAllocatedResource data);     
        
        bool UpdateTestInformationByBatchId(ProductionBatch data);        

        bool Save();
    }
}
