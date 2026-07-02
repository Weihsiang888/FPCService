namespace FPCService.Data
{
    public class YarnSpool
    {
        public int UID { get; set; }
        public string YarnSpoolUid { get; set; }
        public string YarnSpoolStatus { get; set; }
        public string YarnSpoolType { get; set; }
        public string AgvUid { get; set; }
        public string PlaceUid { get; set; }
        public string PlaceSlotUid { get; set; }
        public string StorageRackUid { get; set; }
        public string RackSlotUid { get; set; }
        public string TaskUid { get; set; }
        public int Floor { get; set; }
        public DateTime ProcessTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? CompleteTime { get; set; }
        public DateTime? PlaceTime { get; set; }
        public DateTime? StorageTime { get; set; }
        public DateTime? PackagingTime { get; set; }
        public DateTime? EventTime { get; set; }
    }
}
