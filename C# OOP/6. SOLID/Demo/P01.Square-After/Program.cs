using P01._Square_Before;
using System;


namespace P01.Square_After
{
    public class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Square();
            ResizeShape(rec);
        }

        public static void ResizeShape(Rectangle rec)
        {
            rec.Height = rec.Height * 10;
        }
    }
}
