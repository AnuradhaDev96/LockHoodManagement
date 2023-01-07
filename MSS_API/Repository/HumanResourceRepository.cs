using MSS_API.Data;
using MSS_API.Interfaces;
using MSS_API.Models.Departments;
using MSS_API.Models.EmployeeUsers;
using MSS_API.Models.WorkMonitoring;

namespace MSS_API.Repository
{
    public class HumanResourceRepository : IHumanResourceRepository
    {
        private readonly DataContext _context;

        public HumanResourceRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Department> GetDepartments()
        {
            return _context.Departments.OrderBy(w => w.Id).ToList();
        }

        public ICollection<EmployeeUser> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public EmployeeUser? GetEmployeeUser(string email)
        {
            return _context.EmployeeUsers.Where(w => w.Email == email).FirstOrDefault();
        }

        public ICollection<KanBanTask> GetAllKanBanTasks()
        {
            return _context.KanBanTasks.OrderBy(w => w.Id).ToList();
        }
    }
}
