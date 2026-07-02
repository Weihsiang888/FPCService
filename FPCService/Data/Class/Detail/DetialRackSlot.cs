namespace FPCService.Data
{
    public class DetialRackSlot
    {
        public int UID { get; set; }
        public string RackSlotUid { get; set; }
        public string StorageRackUid { get; set; }
        public int RackSlotPoint { get; set; }
        public string RackSlotStatus { get; set; }
        public string YarnSpoolType { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public DateTime OccurrenceTime { get; set; }
    }
}
