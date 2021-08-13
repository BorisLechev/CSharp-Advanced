using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            var tasks = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var threads = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var taskToKill = int.Parse(Console.ReadLine());

            var threadsQueue = new Queue<int>(threads);
            var tasksStack = new Stack<int>(tasks);

            while (threadsQueue.Any() && tasksStack.Any())
            {
                var currentThread = threadsQueue.Peek();
                var currentTask = tasksStack.Peek();

                if (currentTask == taskToKill)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {currentTask}");
                    Console.WriteLine(string.Join(" ", threadsQueue));
                    break;
                }

                if (currentThread >= currentTask)
                {
                    threadsQueue.Dequeue();
                    tasksStack.Pop();
                }
                else
                {
                    threadsQueue.Dequeue();
                }
            }
        }
    }
}
