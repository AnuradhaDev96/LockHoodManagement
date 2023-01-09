using MSS_API.Models.AutomatedWarehouseRequests;
using MSS_API.Models.Inventories;
using MSS_API.Models.Workshops;

namespace MSS_API.Interfaces
{
    public interface IInventoryRepository
    {
        ICollection<Inventory> GetInventories();

        Inventory? GetInventoryByWorkshopId(int workshopId);

        Inventory? GetInventory(int id);

        Inventory? GetInventory(string name);

        InventoryItems? GetInventoryItem(int id);

        bool CheckInventoryIsExist(int id);

        bool CheckWorkshopAlreadyHasInventory(int workshopId);

        string? GetInventoryName(int id);

        bool CreateInventory(Inventory inventory);

        bool UpdateInventory(Inventory inventory);

        bool DeleteInventory(Inventory inventory);

        bool CreateInventoryItem(InventoryItems inventoryItem);

        bool ReduceAmountInInventoryItems(InventoryItems inventoryItem);

        bool Save();

        ICollection<Workshop> GetWorkshopListWithSingleInventory();

        ICollection<InventoryItems> GetItemsListOfInventory(int inventoryId);

        ICollection<InventoryItems> GetAllItemsList();

        bool CreateAutomatedInventoryRequest(AutomatedWarehouseRequest request);
    }
}
