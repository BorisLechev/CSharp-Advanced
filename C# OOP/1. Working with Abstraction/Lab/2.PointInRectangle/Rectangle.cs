using System;
using System.Collections.Generic;
using System.Text;

namespace _2.PointInRectangle
{
    public class Rectangle
    {
        public Point TopLeftPoint { get; set; }

        public Point BottomRightPoint { get; set; }

        public Rectangle(Point topLeftPoint, Point bottomRightPoint)
        {
            this.TopLeftPoint = topLeftPoint;
            this.BottomRightPoint = bottomRightPoint;
        }

        public bool Contains(Point point)
        {
            bool isInsideByX = point.CoordinateX >= this.TopLeftPoint.CoordinateX
                && point.CoordinateX <= this.BottomRightPoint.CoordinateX;

            bool isInsideByY = point.CoordinateY >= this.TopLeftPoint.CoordinateY
                && point.CoordinateY <= this.BottomRightPoint.CoordinateY;

            return isInsideByX && isInsideByY;
        }
    }
}
