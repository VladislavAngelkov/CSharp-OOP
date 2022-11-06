using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public abstract class Car : ICar
    {
        public Car(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; set; }
        public string Color { get; set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }
        public override string ToString()
        {
            return $"{Color} {this.GetType().Name} {Model}";
        }
    }
}
