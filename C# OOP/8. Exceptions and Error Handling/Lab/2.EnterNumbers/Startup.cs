using System;

namespace _2.EnterNumbers
{
    public class Startup
    {
        public static void Main()
        {
            int start = 0;
            int end = 100;

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    ReadNumber(start, end);
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    throw new ArgumentOutOfRangeException(aoore.Message);
                }
                catch (FormatException)
                {
                    throw new FormatException();
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }

        private static void ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            int.TryParse(input, out int number);

            if (number != 0)
            {
                if (number < start || number > end)
                {
                    throw new ArgumentOutOfRangeException("number", "Number should be integer in range [1...100]");
                }
            }

            else
            {
                throw new FormatException("Invalid input.");
            }

            Console.WriteLine(number);
        }
    }
}
