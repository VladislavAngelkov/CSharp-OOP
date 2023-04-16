
namespace BookingApp.Repositories
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Contracts;
    using Models.Rooms;
    using BookingApp.Models.Rooms.Contracts;

    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> rooms;
        public RoomRepository()
        {
            rooms = new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
            rooms.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return new ReadOnlyCollection<IRoom>(rooms);
        }

        public IRoom Select(string criteria)
        {
            return rooms.FirstOrDefault(r => Type.GetType($"BookingApp.Models.Rooms.{criteria}").IsAssignableFrom(r.GetType()));
        }
    }
}
