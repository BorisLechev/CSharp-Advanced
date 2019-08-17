using System;

namespace CustomRandomList
{
    public class CustomRandomList
    {
        public static void Main()
        {
            var randomList = new RandomList<int>();

            for (int i = 0; i < 50; i++)
            {
                randomList.Add(i);
            }

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(randomList.RemoveRandomElement());
            }
        }
    }
}
