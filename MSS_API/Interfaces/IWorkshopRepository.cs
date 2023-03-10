using MSS_API.Models.Workshops;

namespace MSS_API.Interfaces
{
    public interface IWorkshopRepository
    {
        ICollection<Workshop> GetWorkshops();

        Workshop? GetWorkshop(int id);

        Workshop? GetWorkshop(string name);

        bool CheckWorkshopIsExist(int id);

        string? GetWorkshopName(int id);

        //bool CreateWorkshop(string name, int factoryId);

        bool CreateWorkshop(Workshop workshop);

        bool UpdateWorkshop(Workshop workshop);

        bool DeleteWorkshop(Workshop workshop);

        bool Save();
    }
}
