using MSS_API.Models.Inventories;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSS_API.Models.WorkMonitoring
{
    public class TaskAllocatedResource
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "AllocatedAmount")]
        public double AllocatedAmount { get; set; }

        [ForeignKey("InventoryItemId")]
        [Display(Name = "Inventory Item Id")]
        public int InventoryItemId { get; set; }
        public InventoryItems inventoryItem { get; set; }

        [ForeignKey("KanBanTaskId")]
        [Display(Name = "KanBan Task Id")]
        public int KanBanTaskId { get; set; }
        public KanBanTask KanBanTask { get; set; }
    }
}
