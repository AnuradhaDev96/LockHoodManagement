using MSS_API.Models.AutomatedWarehouseRequests;
using System.ComponentModel.DataAnnotations;

namespace MSS_API.Models.Workshops
{
    public class WarehouseItem
    {
        [Key]
        [Required]
        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [Display(Name = "Available Quantity")]
        public double AvailableQuantity { get; set; }

        public ICollection<AutomatedRequestWarehouseItem> AutomatedRequestWarehouseItems { get; set; }
    }
}
