namespace FPCService.Data
{
    public class QueueRackSlot
    {
        public int UID { get; set; }
        public int QueueStatus { get; set; }
        public string RackSlotUid { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public DateTime ProcessTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? CompleteTime { get; set; }
    }
}
