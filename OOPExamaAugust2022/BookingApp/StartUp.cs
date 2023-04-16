namespace BookingApp
{
    using BookingApp.Core;
    using BookingApp.Core.Contracts;
    using BookingApp.Models.Hotels;
    using BookingApp.Models.Rooms;
    using BookingApp.Models.Rooms.Contracts;
    using BookingApp.Repositories;

    public class StartUp
    {
        public static void Main()
        {
            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();

            //RoomRepository repo = new RoomRepository();
            //IRoom firstRoom = new DoubleBed();
            //IRoom secondRoom = new Studio();
            //IRoom thirdRoom = new Apartment();

            //repo.AddNew(firstRoom);
            //repo.AddNew(secondRoom);
            //repo.AddNew(thirdRoom);

            //IRoom selected = repo.Select("DoubleBed");

            //System.Console.WriteLine(selected.GetType().Name);
        }
    }
}
