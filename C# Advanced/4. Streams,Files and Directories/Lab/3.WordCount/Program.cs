using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, int>();

            using (var wordsReader = new StreamReader("words.txt"))
            {
                var words = Regex.Matches(wordsReader.ReadLine().ToLower(), "\\w+");

                for (int i = 0; i < words.Count; i++)
                {
                    dictionary.Add(words[i].Value, 0);
                }
            }

            using (var textReader = new StreamReader("text.txt"))
            {
                string line = textReader.ReadLine();

                while (line != null)
                {
                    var words = Regex.Matches(line.ToLower(), "\\w+");

                    foreach (Match word in words)
                    {
                        if (dictionary.ContainsKey(word.Value))
                        {
                            dictionary[word.Value]++;
                        }
                    }

                    line = textReader.ReadLine();
                }
            }

            using (var writer = new StreamWriter("output.txt"))
            {
                foreach (var word in dictionary.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
