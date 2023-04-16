using System;
using System.Collections.Generic;
using System.Text;
using P04.Recharge.Models.Innterfaces;

namespace P04.Recharge.Models
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity) : base(id)
        {
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public int CurrentPower
        {
            get { return currentPower; }
            set { currentPower = value; }
        }

        public override void Work(int hours)
        {
            if (hours > currentPower)
            {
                hours = currentPower;
            }

            base.Work(hours);
            currentPower -= hours;
        }

        public void Recharge()
        {
            currentPower = capacity;
        }
    }
}