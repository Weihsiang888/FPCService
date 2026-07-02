namespace FPCService.Data
{
    public class LogRackSlot
    {
        public int UID { get; set; }
        public string RackSlotUid { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public string Message { get; set; }
        public DateTime ProcessTime { get; set; }
    }
}
