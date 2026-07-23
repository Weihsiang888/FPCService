namespace FPCService.Data
{
    public class DetailYarnMachineSlot
    {
        public int UID { get; set; }
        public string YarnMachineSlotUid { get; set; }
        public string YarnMachineUid { get; set; }
        public int YarnMachineSlotPoint { get; set; }
        public string YarnMachineSlotStatus { get; set; }
        public string YarnSpoolType { get; set; }
        public int Floor { get; set; }
        public string PointCode { get; set; }
        public string TaskUid { get; set; }
        public DateTime OccurrenceTime { get; set; }
    }
}
