using System;

namespace ClassBoxData
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                box.SurfaceOfTheBox(length, width, height);
                box.LateralSurfaceOfTheBox(length, width, height);
                box.VolumeOfTheBox(length, width, height);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
