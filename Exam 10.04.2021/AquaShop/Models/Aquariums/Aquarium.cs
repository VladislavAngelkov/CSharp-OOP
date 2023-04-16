using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            decorations= new List<IDecoration>();
            fish = new List<IFish>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                capacity= value;
            }
        }

        public int Comfort
        {
            get { return this.decorations.Sum(d => d.Comfort); }
        }

        public ICollection<IDecoration> Decorations
        {
            get { return decorations; }
        }

        public ICollection<IFish> Fish
        {
            get { return fish; }
        }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count == capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (var f in this.fish)
            {
                f.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"{name} ({this.GetType().Name}):");
            message.AppendLine($"Fish: {(this.fish.Count > 0 ? string.Join(", ", this.fish.Select(f => f.Name)) : "none")}");
            message.AppendLine($"Decorations: {decorations.Count}");
            message.AppendLine($"Comfort: {this.Comfort}");

            return message.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
