namespace FPCService.Data
{
    public class MainPlace
    {
        public string PlaceUid { get; set; }
        public string PlaceName { get; set; }
        public int PlaceId { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public int PlaceCompletedCount { get; set; }
        public DateTime ProcessTime { get; set; }
    }
}
