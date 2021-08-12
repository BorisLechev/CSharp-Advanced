using System;

namespace PointInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var rectangle = new Rectangle(3, 1, 1, 3);
            Console.WriteLine(rectangle.Contains(new Point(3, 2)));

            var circle = new Circle(0, 0, 2);
            Console.WriteLine(circle.Contains(new Point(0, 0)));
            Console.WriteLine(circle.Contains(new Point(0, 2)));
            Console.WriteLine(circle.Contains(new Point(2, 0)));
            Console.WriteLine(circle.Contains(new Point(2, 2)));
            Console.WriteLine(circle.Contains(new Point(3, 0)));
        }
    }
}
