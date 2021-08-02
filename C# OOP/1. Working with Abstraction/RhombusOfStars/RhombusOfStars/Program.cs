using System;
using System.Text;

namespace RhombusOfStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var drawer = new RhombusAsStringDrawer();
            Console.WriteLine(drawer.Draw(n));
        }
    }
}
