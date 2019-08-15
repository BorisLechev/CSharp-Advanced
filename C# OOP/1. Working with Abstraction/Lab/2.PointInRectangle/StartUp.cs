using System;
using System.Linq;

namespace _2.PointInRectangle
{
    public class Program
    {
        public static void Main()
        {
            int[] coordinates = ParseInput();

            Point topLeft = new Point(coordinates[0], coordinates[1]);
            Point bottomRight = new Point(coordinates[2], coordinates[3]);

            Rectangle rectangle = new Rectangle(topLeft, bottomRight);

            int numberOfPoints = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPoints; i++)
            {
                int[] coordinateOfPoints = ParseInput();

                Point point = new Point(coordinateOfPoints[0], coordinateOfPoints[1]);

                Console.WriteLine(rectangle.Contains(point));
            }
        }

        private static int[] ParseInput()
        {
            return Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
