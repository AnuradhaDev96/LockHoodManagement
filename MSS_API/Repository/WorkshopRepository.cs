using MSS_API.Data;
using MSS_API.Interfaces;
using MSS_API.Models.Workshops;

namespace MSS_API.Repository
{
    public class WorkshopRepository : IWorkshopRepository
    {
        private readonly DataContext _context;

        public WorkshopRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Workshop> GetWorkshops()
        {
            return _context.Workshops.OrderBy(w => w.Id).ToList();
        }

        public Workshop? GetWorkshop(int id)
        {
            return _context.Workshops.Where(w => w.Id == id).FirstOrDefault();
        }

        public Workshop? GetWorkshop(string name)
        {
            return _context.Workshops.Where(w => w.Name == name).FirstOrDefault();
        }

        public bool CheckWorkshopIsExist(int id)
        {
            return _context.Workshops.Any(w => w.Id == id);
        }

        public string? GetWorkshopName(int id)
        {
           return _context.Workshops.Where(w => w.Id == id).FirstOrDefault().Name;
        }

        public bool CreateWorkshop(Workshop workshop)
        {
            //var workshop = new Workshop()
            //{
            //    Name = name,
            //    FactoryId = factoryId,
            //};

            _context.Workshops.Add(workshop);

            return Save();

        }

        public bool UpdateWorkshop(Workshop workshop)
        {
            _context.Workshops.Update(workshop);
            return Save();
        }

        public bool DeleteWorkshop(Workshop workshop)
        {
            _context.Workshops.Remove(workshop);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }        
    }
}
