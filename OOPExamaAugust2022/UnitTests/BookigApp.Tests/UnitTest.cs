using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("Test Hotel", 3);
        }

        [Test]
        public void Test_HotelShouldTrowExceptionIfNameIsNullOrWhitespace()
        {
            Assert.Throws<ArgumentNullException>(() =>
            hotel = new Hotel("", 1));
            Assert.Throws<ArgumentNullException>(() =>
            hotel = new Hotel(null, 1)); ;
        }

        [Test]
        public void Test_HotelShouldTrowExceptionIfCategoryIsLessThenOne()
        {
            Assert.Throws<ArgumentException>(() =>
            hotel = new Hotel("Test Hotel", 0));
        }
        [Test]
        public void Test_HotelShouldTrowExceptionIfCategoryIsMoreThenFive()
        {
            Assert.Throws<ArgumentException>(() =>
            hotel = new Hotel("Test Hotel", 6));
        }

        [Test]
        public void Test_NameSouldBeSetCorrectly()
        {
            Assert.AreEqual("Test Hotel", hotel.FullName);
        }

        [Test]
        public void Test_CategoryShouldBeSetCorrectly()
        {
            Assert.AreEqual(3, hotel.Category);
        }

        [Test]
        public void Test_AddRoomMethodShouldWorkCorrectly()
        {
            Room roomOne = new Room(2, 100);
            hotel.AddRoom(roomOne);
            Assert.AreEqual(1, hotel.Rooms.Count);
            hotel.AddRoom(roomOne);
            Assert.AreEqual(2, hotel.Rooms.Count);
            hotel.AddRoom(roomOne);
            Assert.AreEqual(3, hotel.Rooms.Count);
        }

        [Test]
        public void Test_ShouldThrowExeptionIfAdultsAreLessOrEqualToZero()
        {
            int adults = 0;
            int children = 1;
            int duration = 3;
            double budget = 300;

            Assert.Throws<ArgumentException>(() =>
            hotel.BookRoom(adults, children, duration, budget));

            adults = -3;

            Assert.Throws<ArgumentException>(() =>
            hotel.BookRoom(adults, children, duration, budget));
        }

        [Test]
        public void Test_ShouldThrowExeptionIfChildernAreLessThenZero()
        {
            int adults = 2;
            int children = -2;
            int duration = 3;
            double budget = 300;

            Assert.Throws<ArgumentException>(() =>
            hotel.BookRoom(adults, children, duration, budget));
        }

        [Test]
        public void Test_ShouldThrowExeptionIfResidenceDurationIsLessThenOne()
        {
            int adults = 2;
            int children = 2;
            int duration = 0;
            double budget = 300;

            Assert.Throws<ArgumentException>(() =>
            hotel.BookRoom(adults, children, duration, budget));

            duration = -5;

            Assert.Throws<ArgumentException>(() =>
            hotel.BookRoom(adults, children, duration, budget));
        }

        [Test]
        public void Test_BookRoomShouldWorkCorrectly()
        {
            Room roomOne = new Room(4, 100);
            hotel.AddRoom(roomOne);
            int adults = 2;
            int children = 2;
            int duration = 2;
            double budget = 300;
            hotel.BookRoom(adults, children, duration, budget);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(200, hotel.Turnover);

        }
    }
}