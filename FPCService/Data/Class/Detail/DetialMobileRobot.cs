namespace FPCService.Data
{
    public class DetialMobileRobot
    {
        public int UID { get; set; }
        public string MobileRobotUid { get; set; }
        public string MobileRobotStatus { get; set; }
        public string MobileRobotType { get; set; }
        public string SwarmCoreId { get; set; }
        public string PointCode { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public DateTime OccurrenceTime { get; set; }
    }
}
