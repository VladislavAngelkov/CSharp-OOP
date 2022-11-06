

namespace Shapes
{
    using System;
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get { return radius; }
            private set
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException("Radius cannot be zero or negative!");
                //}

                radius = value;
            }
        }
        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * radius;
        }
        public override string Draw()
        {
            return base.Draw() + $" {this.GetType().Name}";
        }
    }
}
