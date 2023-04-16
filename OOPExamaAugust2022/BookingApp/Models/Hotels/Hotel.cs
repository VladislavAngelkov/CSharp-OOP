
namespace BookingApp.Models.Hotels
{
    using System;
    using System.Linq;

    using Contacts;
    using Bookings.Contracts;
    using Rooms.Contracts;
    using Repositories.Contracts;
    using Utilities.Messages;
    using BookingApp.Repositories;
    using BookingApp.Models.Rooms;
    using BookingApp.Models.Bookings;

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private readonly IRepository<IRoom> rooms;
        private readonly IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            rooms= new RoomRepository();
            bookings= new BookingRepository();
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                fullName = value;
            }
        }

        public int Category
        {
            get { return category; }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                category = value;
            }
        }

        public double Turnover
        {
            get { return Math.Round(Bookings.All().Sum(rep => rep.ResidenceDuration * rep.Room.PricePerNight), 2); }
        }

        public IRepository<IRoom> Rooms
        {
            get { return rooms; }
        }

        public IRepository<IBooking> Bookings
        {
            get { return bookings; }
        }
    }
}
