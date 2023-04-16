namespace BookingApp.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Contracts;
    using BookingApp.Models.Hotels.Contacts;

    public class HotelRepository : IRepository<IHotel>
    {
        private readonly List<IHotel> hotels;
        public HotelRepository()
        {
            hotels = new List<IHotel>();
        }
        public void AddNew(IHotel model)
        {
            hotels.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return new ReadOnlyCollection<IHotel>(hotels);
        }

        public IHotel Select(string criteria)
        {
            return hotels.FirstOrDefault(h => h.FullName == criteria);
        }
    }
}
