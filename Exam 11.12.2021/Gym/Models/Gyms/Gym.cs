using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private double equipmentWeight;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            equipment = new List<IEquipment>();
            athletes= new List<IAthlete>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                capacity = value;
            }
        }

        public double EquipmentWeight
        {
            get
            {
                return equipment.Sum(e => e.Weight);
            }
        }

        public ICollection<IEquipment> Equipment
        {
            get
            {
                return equipment;
            }
        }

        public ICollection<IAthlete> Athletes
        {
            get
            {
                return athletes;
            }
        }

        public void AddAthlete(IAthlete athlete)
        {
            if (athletes.Count==capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }

            athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"{name} is a {this.GetType().Name}:");
            string athletesInTheGym = string.Join(", ", athletes.Select(a => a.FullName));
            message.AppendLine($"Athletes: {(athletes.Count != 0 ? athletesInTheGym : "No athletes")}");
            message.AppendLine($"Equipment total count: {equipment.Count}");
            message.AppendLine($"Equipment total weight: {EquipmentWeight:f2} grams");

            return message.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return athletes.Remove(athlete);
        }
    }
}
