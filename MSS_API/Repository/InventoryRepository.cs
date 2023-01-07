using MSS_API.Data;
using MSS_API.Dto;
using MSS_API.Interfaces;
using MSS_API.Models.Inventories;
using MSS_API.Models.Workshops;
using System.Web.Http;

namespace MSS_API.Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        //use Select or Include to add sub entities in GET
        private readonly DataContext _context;

        public InventoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CheckInventoryIsExist(int id)
        {
            //return _context.Inventories.Where(x => x.Id == id).Select(c => c.InventoryItems).ToList();
            return _context.Inventories.Any(w => w.Id == id);
        }

        public bool CheckWorkshopAlreadyHasInventory(int workshopId)
        {
            return _context.Inventories.Select(x => x.Workshop).Any(y => y.Id == workshopId);
        }

        public bool CreateInventory(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            return Save();
        }

        public bool DeleteInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public ICollection<Inventory> GetInventories()
        {
            return _context.Inventories.OrderBy(w => w.Id).ToList();
        }

        public ICollection<Workshop> GetWorkshopListWithSingleInventory()
        {
            return _context.Inventories.Select(x => x.Workshop).ToList();
        }

        public Inventory? GetInventory(int id)
        {
            return _context.Inventories.Where(w => w.Id == id).FirstOrDefault();
        }

        public Inventory? GetInventory(string name)
        {
            throw new NotImplementedException();
        }

        public string? GetInventoryName(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateInventory(Inventory inventory)
        {
            throw new NotImplementedException();
        }

        public bool CreateInventoryItem(InventoryItems inventoryItem)
        {
            _context.InventoryItems.Add(inventoryItem);
            return Save();
        }



        public Inventory? GetInventoryByWorkshopId(int workshopId)
        {
            return _context.Inventories.Where(w => w.WorkshopId == workshopId).FirstOrDefault();
        }

        public ICollection<InventoryItems> GetItemsListOfInventory(int inventoryId)
        {
            return _context.InventoryItems.OrderBy(w => w.Id).Where(x => x.InventoryId == inventoryId).ToList();
        }

        public ICollection<InventoryItems> GetAllItemsList()
        {
            return _context.InventoryItems.OrderBy(w => w.Id).ToList();
        }
    }
}
