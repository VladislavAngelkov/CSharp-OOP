namespace BookingApp.Models.Bookings
{
    using System;
    using System.Text;

    using Contracts;
    using Rooms.Contracts;
    using Utilities.Messages;
    internal class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get { return residenceDuration; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get { return adultsCount; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get { return childrenCount; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                childrenCount = value;
            }
        }

        public int BookingNumber
        {
            get { return bookingNumber; }
        }

        public string BookingSummary()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Booking number: {BookingNumber}");
            message.AppendLine($"Room type: {Room.GetType().Name}");
            message.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            message.AppendLine($"Total amount paid: {TotalPaid():F2} $");

            return message.ToString().TrimEnd();
        }

        private double TotalPaid()
        {
            return Math.Round(residenceDuration * Room.PricePerNight, 2);
        }
    }
}
