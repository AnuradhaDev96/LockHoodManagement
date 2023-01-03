using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using MSS_API.Models.Workshops;
using System.ComponentModel.DataAnnotations.Schema;

namespace MSS_API.Models.Inventories
{
    public class Inventory
    {
        [Key]
        [Display(Name = "Id")]
        [SwaggerSchema(Description = "Identity value of the inventory")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [SwaggerSchema(Description = "Name of the inventory")]
        public string Name { get; set; }

        //Inventory has One Workshop (1-1 relationship)
        [ForeignKey("Workshop")]
        [Display(Name = "Workshop")]
        //[SwaggerSchema(Description = "Workshop that the inventory belongs to")]
        public int WorkshopId { get; set; }
        public Workshop Workshop { get; set; }

        //Inventory has Many InventoryItems (1-M relationship)
        [Display(Name = "Inventory Items")]
        [SwaggerSchema(Description = "Items of an inventory")]
        public ICollection<InventoryItems> InventoryItems { get; set; }
    }
}
