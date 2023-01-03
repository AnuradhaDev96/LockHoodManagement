using MSS_API.Models.Inventories;
using MSS_API.Models.Workshops;

namespace MSS_API.Interfaces
{
    public interface IInventoryRepository
    {
        ICollection<Inventory> GetInventories();

        Inventory? GetInventory(int id);

        Inventory? GetInventory(string name);

        bool CheckInventoryIsExist(int id);

        bool CheckWorkshopAlreadyHasInventory(int workshopId);

        string? GetInventoryName(int id);

        bool CreateInventory(Inventory inventory);

        bool UpdateInventory(Inventory inventory);

        bool DeleteInventory(Inventory inventory);

        bool CreateInventoryItem(InventoryItems inventoryItem);

        bool Save();

        ICollection<Workshop> GetWorkshopListWithSingleInventory();

    }
}
