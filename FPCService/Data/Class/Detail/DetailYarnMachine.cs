namespace FPCService.Data
{
    public class DetailYarnMachine
    {
        public int UID { get; set; }
        public string YarnMachineUid { get; set; }
        public string YarnMachineStatus { get; set; }
        public string WorderOrder { get; set; }
        public string YarnSpoolType { get; set; }
        public int Floor { get; set; }
        public int YarnSpoolCompletedCount { get; set; }
        public string TaskUid { get; set; }
        public DateTime OccurrenceTime { get; set; }
    }
}
