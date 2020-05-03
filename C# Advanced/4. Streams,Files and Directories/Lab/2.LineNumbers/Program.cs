using System.IO;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader($"input.txt"))
            {
                using (var writer = new StreamWriter("output.txt"))
                {
                    int lineNumber = 1;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        writer.WriteLine($"{lineNumber}. {line}");

                        lineNumber++;
                    }
                }
            }
        }
    }
}
