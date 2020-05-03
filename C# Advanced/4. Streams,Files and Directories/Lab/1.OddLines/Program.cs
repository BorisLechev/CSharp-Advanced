using System.IO;

namespace _1.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader($"input.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    int counter = 0;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                    }
                }
            }
        }
    }
}
