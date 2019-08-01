using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.AverageStudentGrade
{
    class AverageStudentGrade
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> dictionary = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] studentInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                double grade = double.Parse(studentInput[1]);

                if (!dictionary.ContainsKey(studentInput[0]))
                {
                    dictionary[studentInput[0]] = new List<double>();
                }

                dictionary[studentInput[0]].Add(grade);
            }

            foreach (var item in dictionary)
            {
                Console.Write($"{item.Key} -> ");

                foreach (var grade in item.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {item.Value.Average():f2})");
            }
        }
    }
}
