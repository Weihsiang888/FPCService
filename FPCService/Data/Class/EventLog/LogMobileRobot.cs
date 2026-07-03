namespace FPCService.Data
{
    public class LogMobileRobot
    {
        public int UID { get; set; }
        public string MobileRobotUid { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public string Message { get; set; }
        public DateTime ProcessTime { get; set; }
    }
}
