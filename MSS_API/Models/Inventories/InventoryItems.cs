using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace MSS_API.Models.Inventories
{
    public class InventoryItems
    {
        [Key]
        [Display(Name = "Id")]
        [SwaggerSchema(Description = "Identity value of the inventory item")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [SwaggerSchema(Description = "Name of the item")]
        public string Name { get; set; }

        [Display(Name = "Alert Margin")]
        [SwaggerSchema(Description = "Minimum value requires to make a inventory request")]
        public double AlertMargin { get; set; }

        [Display(Name = "Available Quantity")]
        [SwaggerSchema(Description = "Available quantity of item")]
        public double AvailableQuantity { get; set; }

        //Inventory item has One inventory (1-M relationship)
        [Display(Name = "Inventory")]
        [SwaggerSchema(Description = "Inventory that item belongs to")]
        public Inventory Inventory { get; set; }
    }
}
