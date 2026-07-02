namespace FPCService.Data
{
    public class LogPackaging
    {
        public int UID { get; set; }
        public string PackagingUid { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public string Message { get; set; }
        public DateTime ProcessTime { get; set; }
    }
}
