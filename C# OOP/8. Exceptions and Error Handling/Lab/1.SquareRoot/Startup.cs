using System;

namespace _1.SquareRoot
{
    public class Startup
    {
        public static void Main()
        {
            try
            {
                Sqrt();
            }
            catch (OverflowException fe)
            {
                throw new OverflowException("You should enter an integer number.", fe);
            }
            catch (ArgumentException ae)
            {
                throw new ArgumentException($"Error: {ae}");
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                Console.WriteLine("Good bye.");
            }
        }

        private static double Sqrt()
        {
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("number", "The Number should be possitive.");
            }

            return Math.Sqrt(number);
        }
    }
}
