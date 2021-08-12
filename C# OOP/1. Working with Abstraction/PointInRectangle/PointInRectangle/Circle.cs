using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInRectangle
{
    public class Circle
    {
        public Circle(int x, int y, int radius)
        {
            this.Center = new Point(x, y);
            this.Radius = radius;
        }

        public Point Center { get; set; }

        public int Radius { get; set; }

        public bool Contains(Point point)
        {
            // point center
            var distance = Math.Sqrt((point.X - this.Center.X) * (point.X - this.Center.X)
                    + (point.Y - this.Center.Y) * (point.Y - this.Center.Y));

            return distance <= this.Radius;
        }
    }
}
