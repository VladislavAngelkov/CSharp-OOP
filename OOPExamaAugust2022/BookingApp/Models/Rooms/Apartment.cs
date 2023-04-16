namespace BookingApp.Models.Rooms
{
    public class Apartment : Room
    {
        private const int defaultBedCapacity = 6;
        public Apartment() 
            : base(defaultBedCapacity)
        {
        }
    }
}
