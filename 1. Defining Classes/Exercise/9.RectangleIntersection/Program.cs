using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var numbersInput = Console.ReadLine().Split(" ");
        int numberOfRectangles = int.Parse(numbersInput[0]);
        int numberOfIntersectionChecks = int.Parse(numbersInput[1]);

        var rectangles = new List<Rectangle>();

        for (int i = 0; i < numberOfRectangles; i++)
        {
            var rectangleData = Console.ReadLine().Split(" ");

            rectangles.Add(new Rectangle(rectangleData[0], double.Parse(rectangleData[1]), double.Parse(rectangleData[2]),
                double.Parse(rectangleData[3]), double.Parse(rectangleData[4])));
        }

        for (int i = 0; i < numberOfIntersectionChecks; i++)
        {
            var finalIds = Console.ReadLine().Split(" ");

            string firstId = finalIds[0];
            string secondId = finalIds[1];

            Rectangle firstRectangle = rectangles.First(r => r.Id == firstId);
            Rectangle secondRectangle = rectangles.First(r => r.Id == secondId);

            Console.WriteLine(firstRectangle.IsIntersect(secondRectangle).ToString().ToLower());
        }
    }
}