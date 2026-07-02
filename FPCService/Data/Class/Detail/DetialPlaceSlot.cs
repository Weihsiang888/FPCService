namespace FPCService.Data
{
    public class DetialPlaceSlot
    {
        public int UID { get; set; }
        public string PlaceSlotUid { get; set; }
        public string PlaceUid { get; set; }
        public int PlaceSlotPoint { get; set; }
        public string PlaceSlotStatus { get; set; }
        public int Floor { get; set; }
        public string TaskUid { get; set; }
        public DateTime OccurrenceTime { get; set; }
    }
}
