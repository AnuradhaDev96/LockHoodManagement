using MSS_API.Models.Inventories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSS_API.Models.AutomatedWarehouseRequests
{
    public class AutomatedWarehouseRequest
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        //Request has 1 Inventory (1-M relationship)
        [ForeignKey("Inventory")]
        [Display(Name = "Inventory")]
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public ICollection<AutomatedRequestWarehouseItem> AutomatedRequestWarehouseItems { get; set; }
    }
}
