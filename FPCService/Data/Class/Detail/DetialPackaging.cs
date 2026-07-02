namespace FPCService.Data
{
    public class DetialPackaging
    {
        public int UID { get; set; }
        public string PackagingUid { get; set; }
        public int PackagingPoint { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public DateTime OccurrenceTime { get; set; }
    }
}
