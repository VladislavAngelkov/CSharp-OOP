using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Draw()
        {
            Console.WriteLine(new string('*', width));
            for (int i = 1; i < height-1; i++)
            {
                DrawLine(width, '*', ' ');
            }
            Console.WriteLine(new string('*', width));
        }

        private void DrawLine(int width , char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width-1; i++)
            {
                Console.Write(mid);
            }
            Console.Write(end);
            Console.WriteLine();
        }
    }
}
