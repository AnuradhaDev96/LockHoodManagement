namespace MSS_API.Dto
{
    public class InventoryItemsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AlertMargin { get; set; }
        public double AvailableQuantity { get; set; }
        public int InventoryId { get; set; }
    }
}
