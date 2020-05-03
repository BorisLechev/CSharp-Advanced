using System;
using System.IO;

namespace _5.SliceFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new FileStream("input.txt", FileMode.Open))
            {
                int fileParts = (int)(Math.Ceiling(reader.Length / 4.0));
                byte[] buffer = new byte[4096];

                for (int i = 1; i <= 4; i++)
                {
                    int totalWrite = 0;
                    string fileName = $"part - {i}.txt";

                    using (FileStream writer = new FileStream($"{fileName}", FileMode.Create))
                    {
                        while (true)
                        {
                            int readerLength = Math.Min(buffer.Length, fileParts - totalWrite);
                            int currentRead = reader.Read(buffer, 0, readerLength);

                            if (currentRead == 0)
                            {
                                return;
                            }

                            writer.Write(buffer, 0, currentRead);
                            totalWrite += currentRead;

                            if (totalWrite >= fileParts)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
