using _5.BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.BorderControl
{
    public class StartUp
    {
        public static void Main()
        {
            List<IIdentifiable> identifiables = new List<IIdentifiable>();

            while (true)
            {
                string[] tokens =
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "End")
                {
                    break;
                }

                if (tokens.Length == 3)
                {
                    string name = tokens[0];
                    string age = tokens[1];
                    string id = tokens[2];

                    IIdentifiable citizen = new Citizen(name, age, id);

                    identifiables.Add(citizen);
                }

                else if (tokens.Length == 2)
                {
                    string model = tokens[0];
                    string id = tokens[1];

                    IIdentifiable robot = new Robot(model, id);

                    identifiables.Add(robot);
                }
            }

            string lastDigitsOfFakeId = Console.ReadLine();

            //identifiables
            //    .ForEach(id =>
            //    {
            //        int idLength = id.Id.Length;
            //        int lastDigitsOfFakeIdLength = lastDigitsOfFakeId.Length;

            //        if (id.Id.Substring(idLength - lastDigitsOfFakeIdLength) == lastDigitsOfFakeId)
            //        {
            //            Console.WriteLine(id.Id);
            //        }
            //    });
            List<string> ids =
                identifiables
                .Where(i => i.Id.EndsWith(lastDigitsOfFakeId))
                .Select(i => i.Id)
                .ToList();

            Console.WriteLine(string.Join(Environment.NewLine, ids));
        }
    }
}
