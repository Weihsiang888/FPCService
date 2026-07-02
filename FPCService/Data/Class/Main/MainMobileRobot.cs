namespace FPCService.Data
{
    public class MainMobileRobot
    {
        public string MobileRobotUid { get; set; }
        public string MobileRobotStatus { get; set; }
        public string MobileRobotType { get; set; }
        public string SwarmCoreId { get; set; }
        public string PlaceUid { get; set; }
        public int Floor { get; set; }
        public int? Battery { get; set; }
        public string TaskUid { get; set; }
        public DateTime ProcessTime { get; set; }
    }
}
