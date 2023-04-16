using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotelRepository;

        public Controller()
        {
            this.hotelRepository = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotelRepository.All().Any(h=>h.FullName == hotelName && h.Category == category))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            else
            {
                Hotel hotel = new Hotel(hotelName, category);
                hotelRepository.AddNew(hotel);

                return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
            }
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            var allHotels = hotelRepository.All();
            if (!allHotels.Any(h=>h.Category==category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            var hotels = hotelRepository.All().OrderBy(h=>h.FullName);
            var rooms = new List<IRoom>();
            foreach (var hotel in hotels)
            {
                var currentRooms = hotel.Rooms.All();
                rooms.AddRange(currentRooms);
            }

            rooms = rooms.Where(r=>r.PricePerNight>0 && r.BedCapacity>=(adults+children)).OrderBy(r=>r.BedCapacity).ToList();

            var room = rooms.FirstOrDefault();

            if (room == null)
            {
                return OutputMessages.RoomNotAppropriate;
            }
            else
            {
                int totalBookingAppBookingsCount = hotelRepository.All().Sum(h => h.Bookings.All().Count);
                Booking booking = new Booking(room, duration, adults, children, totalBookingAppBookingsCount + 1);

                Hotel hotel = (Hotel)hotelRepository.All().FirstOrDefault(h => h.Rooms.All().Any(r => r.BedCapacity == room.BedCapacity && r.GetType().Name == room.GetType().Name));

                hotelRepository.All().First(h=>h.Rooms.All().Any(r=>r.BedCapacity == room.BedCapacity && r.GetType().Name == room.GetType().Name)).Bookings.AddNew(booking);

                return string.Format(OutputMessages.BookingSuccessful, totalBookingAppBookingsCount + 1, hotel.FullName);
            }
        }

        public string HotelReport(string hotelName)
        {
            if (!hotelRepository.All().Any(h=>h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            Hotel hotel = (Hotel)hotelRepository.All().First(h => h.FullName == hotelName);

            StringBuilder message = new StringBuilder();
            message.AppendLine($"Hotel name: {hotelName}");
            message.AppendLine($"--{hotel.Category} star hotel");
            message.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            message.AppendLine("--Bookings:");
            message.AppendLine();

            foreach (var booking in hotel.Bookings.All())
            {
                message.AppendLine(booking.BookingSummary());
                message.AppendLine();
            }

            return message.ToString().TrimEnd();  
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!hotelRepository.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            else if (Type.GetType($"BookingApp.Models.Rooms.{roomTypeName}") == null)
            {
                throw new ArgumentException("Incorrect room type!");
            }
            else if (!hotelRepository.All()
                .First(h => h.FullName == hotelName)
                .Rooms.All()
                .Any(r => r.GetType().IsAssignableFrom(Type.GetType($"BookingApp.Models.Rooms.{roomTypeName}"))))
            {
                return OutputMessages.RoomTypeNotCreated;
            }
            else if (hotelRepository.All().First(h=>h.FullName == hotelName).Rooms.All().First(r => r.GetType().IsAssignableFrom(Type.GetType($"BookingApp.Models.Rooms.{roomTypeName}"))).PricePerNight!=0)
            {
                return "Price is already set!";
            }
            else
            {
                hotelRepository.All()
                    .First(h => h.FullName == hotelName)
                    .Rooms.All()
                    .First(r => r.GetType().IsAssignableFrom(Type.GetType($"BookingApp.Models.Rooms.{roomTypeName}")))
                    .SetPrice(price);

                return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
            }
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotelRepository.All().Any(h=>h.FullName==hotelName))
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            else if (Type.GetType($"BookingApp.Models.Rooms.{roomTypeName}") == null)
            {
                throw new ArgumentException("Incorrect room type!");
            }
            else if (hotelRepository.All().First(h => h.FullName == hotelName).Rooms.All().Any(r=>r.GetType().IsAssignableFrom(Type.GetType($"BookingApp.Models.Rooms.{roomTypeName}"))))
            {
                return OutputMessages.RoomTypeAlreadyCreated;
            }
            else
            {
                var room = (IRoom)Activator.CreateInstance(Type.GetType($"BookingApp.Models.Rooms.{roomTypeName}"));

                hotelRepository.All().First(h => h.FullName == hotelName).Rooms.AddNew(room);

                return string.Format(OutputMessages.RoomTypeAdded, room.GetType().Name, hotelName);
            }
        }
    }
}
