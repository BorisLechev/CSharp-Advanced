using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> vloggers = new Dictionary<string, List<string>>();
            Dictionary<string, int> following = new Dictionary<string, int>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[1] == "joined" && !vloggers.ContainsKey(tokens[0]))
                {
                    vloggers.Add(tokens[0], new List<string>());
                    following[tokens[0]] = 0;
                }

                else
                {
                    if (vloggers.ContainsKey(tokens[0]) && vloggers.ContainsKey(tokens[2]) 
                        && tokens[0] != tokens[2] && vloggers[tokens[0]].Contains(tokens[2]) == false)
                    {
                        following[tokens[2]]++;
                        vloggers[tokens[0]].Add(tokens[2]);
                    }
                }
            }

            Dictionary<string, int[]> combinedDic = new Dictionary<string, int[]>();

            foreach (var pair in vloggers)
            {
                string vlogger = pair.Key;
                combinedDic[vlogger] = new int[2];
                combinedDic[vlogger][0] = pair.Value.Count();
                combinedDic[vlogger][1] = following[vlogger];

            }

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            int count = 1;

            foreach (var vlogger in combinedDic.OrderByDescending(v => v.Value[0]).ThenBy(v => v.Value[1]))
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value[0]} followers, {vlogger.Value[1]} following");

                if (count == 1)
                {
                    foreach (string follower in vloggers[vlogger.Key].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }
}
