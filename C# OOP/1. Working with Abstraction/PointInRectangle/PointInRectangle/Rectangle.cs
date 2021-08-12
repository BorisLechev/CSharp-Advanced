using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(int top, int left, int bottom, int right)
        {
            this.TopLeftCoordinates = new Point(left, top);
            this.BottomLeftCoordinates = new Point(right, bottom);
        }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeftCoordinates = topLeft;
            this.BottomLeftCoordinates = bottomRight;
        }

        public Point TopLeftCoordinates { get; set; }

        public Point BottomLeftCoordinates { get; set; }

        public bool Contains(Point point)
        {
            bool isInX = point.X >= this.TopLeftCoordinates.X &&
                point.X <= this.BottomLeftCoordinates.X;

            bool isInY = point.Y <= this.TopLeftCoordinates.Y &&
                point.Y >= this.BottomLeftCoordinates.Y;

            return isInX && isInY;
        }
    }
}
