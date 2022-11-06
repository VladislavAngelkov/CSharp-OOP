
namespace Shapes
{
    using System;
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width
        {
            get { return width; }
            private set
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException("Withd cannot be zero or negative!");
                //}

                width = value;
            }
        }
        public double Height
        {
            get { return height; }
            private set
            {
                //if (value <= 0)
                //{
                //    throw new ArgumentException("Height cannot be zero or negative!");
                //}

                height = value;
            }
        }
        public override double CalculateArea()
        {
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            return 2 * width + 2 * height;
        }

        public override string Draw()
        {
            return base.Draw() + $" {this.GetType().Name}";
        }
    }
}
