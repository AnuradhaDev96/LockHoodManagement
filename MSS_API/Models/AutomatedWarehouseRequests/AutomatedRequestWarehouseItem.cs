using MSS_API.Models.Workshops;
using System.ComponentModel.DataAnnotations;

namespace MSS_API.Models.AutomatedWarehouseRequests
{
    public class AutomatedRequestWarehouseItem
    {
        [Display(Name = "Request Id")]
        public int RequestId { get; set; }
        public AutomatedWarehouseRequest AutomatedWarehouseRequest { get; set; }

        [Display(Name = "Product Code")]
        public string ProductCode { get; set; }
        public WarehouseItem WarehouseItem { get; set; }

        
        [Display(Name = "Quantity")]
        public double Quantity { get; set; }
    }
}
