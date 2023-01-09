namespace MSS_API.Dto
{
    public class TaskAllocatedResourceDto
    {
        public int Id { get; set; }
        public double AllocatedAmount { get; set; }
        public int InventoryItemId { get; set; }
        public int KanBanTaskId { get; set; }
    }
}
