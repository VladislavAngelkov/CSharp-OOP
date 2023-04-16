namespace BookingApp.Models.Rooms
{
    public class Studio : Room
    {
        private const int defaultBedCapacity = 4;
        public Studio() 
            : base(defaultBedCapacity)
        {
        }
    }
}
