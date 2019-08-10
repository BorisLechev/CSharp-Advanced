using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] leftSocks =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> leftSocksStack = new Stack<int>(leftSocks);

            int[] rightSocks =
                 Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> rightSocksQueue = new Queue<int>(rightSocks);

            List<int> pairs = new List<int>();

            while (leftSocksStack.Count > 0 && rightSocksQueue.Count > 0)
            {

            if (leftSocksStack.Peek() > rightSocksQueue.Peek())
            {
                pairs.Add(leftSocksStack.Pop() + rightSocksQueue.Dequeue());
            }

            else if (rightSocksQueue.Peek() > leftSocksStack.Peek())
            {
                leftSocksStack.Pop();

                while (leftSocksStack.Peek() != rightSocksQueue.Peek())
                {
                    leftSocksStack.Pop();
                }

                if (leftSocksStack.Peek() == rightSocksQueue.Peek())
                {
                    rightSocksQueue.Dequeue();

                    int lastElement = leftSocksStack.Pop() + 1;
                    leftSocksStack.Push(lastElement);
                }
            }

            else if (leftSocksStack.Peek() == rightSocksQueue.Peek())
            {
                rightSocksQueue.Dequeue();

                int lastElement = leftSocksStack.Pop() + 1;
                leftSocksStack.Push(lastElement);
            }
            }

            Console.WriteLine(pairs.Max());
            Console.WriteLine(String.Join(" ", pairs));
        }
    }
}
