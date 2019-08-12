using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.ListyIterator
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> createCommand =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            ListyIterator<string> collection = null;

            if (createCommand.Count > 1)
            {
                List<string> elements = createCommand.Skip(1).ToList();
                collection = new ListyIterator<string>(elements);
            }

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    switch (input)
                    {
                        case "HasNext":
                            Console.WriteLine(collection.HasNext());
                            break;
                        case "Move":
                            Console.WriteLine(collection.Move());
                            break;
                        case "Print":
                            collection.Print();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
