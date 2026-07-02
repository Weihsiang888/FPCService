namespace FPCService.Data
{
    public class QueueMobileRobot
    {
        public int UID { get; set; }
        public int QueueStatus { get; set; }
        public string MobileRobotUid { get; set; }
        public string PointCode { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public DateTime ProcessTime { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? CompleteTime { get; set; }
    }
}
