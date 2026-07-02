namespace FPCService.Data
{
    public class LogYarnMachineSlot
    {
        public int UID { get; set; }
        public string YarnMachineSlotUid { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public string Message { get; set; }
        public DateTime ProcessTime { get; set; }
    }
}
