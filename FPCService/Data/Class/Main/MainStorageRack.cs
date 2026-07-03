namespace FPCService.Data
{
    public class MainStorageRack
    {
        public string StorageRackUid { get; set; }
        public string StorageRackName { get; set; }
        public int StorageRackPoint { get; set; }
        public string YarnSpoolType { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public int StorageCompletedCount { get; set; }
        public DateTime ProcessTime { get; set; }
    }
}
