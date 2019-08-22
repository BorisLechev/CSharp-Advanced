using Shapes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private readonly int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        void IDrawable.Draw()
        {
            double tickness = 0.4;
            double rIn = this.radius - tickness;
            double rOut = this.radius + tickness;

            for (double y = this.radius; y >= -this.radius; y--)
            {
                for (double x = -this.radius; x < rOut; x += 0.5)
                {
                    double point = Math.Pow(x, 2) + Math.Pow(y, 2);

                    if (point >= Math.Pow(rIn, 2) && point <= Math.Pow(rOut, 2))
                    {
                        Console.Write('*');
                    }

                    else
                    {
                        Console.Write(' ');
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
