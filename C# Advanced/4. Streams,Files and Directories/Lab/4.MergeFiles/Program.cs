using System.IO;

namespace _4.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader1 = new StreamReader("input1.txt"))
            {
                using (var reader2 = new StreamReader("input2.txt"))
                {
                    using (var writer = new StreamWriter("output.txt"))
                    {
                        while (true)
                        {
                            string firstFileLine = reader1.ReadLine();
                            string secondFileLine = reader2.ReadLine();

                            if (firstFileLine == null && secondFileLine == null)
                            {
                                break;
                            }

                            if (firstFileLine != null)
                            {
                                writer.WriteLine(firstFileLine);
                            }

                            if (secondFileLine != null)
                            {
                                writer.WriteLine(secondFileLine);
                            }
                        }
                    }
                }
            }
        }
    }
}
