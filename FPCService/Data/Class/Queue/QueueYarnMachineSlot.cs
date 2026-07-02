namespace FPCService.Data
{
    public class QueueYarnMachineSlot
    {
        public int UID { get; set; }
        public int QueueStatus { get; set; }
        public string YarnMachineSlotUid { get; set; }
        public string YarnSpoolType { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public string PointCode { get; set; }
        public DateTime ProcessTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? CompleteTime { get; set; }
    }
}
