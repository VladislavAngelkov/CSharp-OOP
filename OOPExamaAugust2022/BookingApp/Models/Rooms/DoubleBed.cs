namespace BookingApp.Models.Rooms
{
    public class DoubleBed : Room
    {
        private const int defaultBedCapacity = 2;
        public DoubleBed() 
            : base(defaultBedCapacity)
        {
        }
    }
}
