using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var bombEffects = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var bombCasting = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var bombEffectsQueue = new Queue<int>(bombEffects);
            var bombCastingStack = new Stack<int>(bombCasting);

            var bombsList = new List<Bomb>
            {
                new Bomb("Datura Bombs", 40),
                new Bomb("Cherry Bombs", 60),
                new Bomb("Smoke Decoy Bombs", 120)
            };

            bool isAllBombsFilled = false;

            while (bombEffectsQueue.Any() && bombCastingStack.Any())
            {
                var currentBombEffect = bombEffectsQueue.Peek();
                var currentBombCasting = bombCastingStack.Peek();

                var sum = currentBombCasting + currentBombEffect;

                if (bombsList.Any(b => b.Damage == sum))
                {
                    var bomb = bombsList.First(b => b.Damage == sum);
                    bomb.Count++;

                    bombEffectsQueue.Dequeue();
                    bombCastingStack.Pop();
                }
                else
                {
                    var bomb = bombsList.First(b => b.Damage == sum);
                    bomb.Count -= 5;
                }

                if (bombsList.All(x => x.Count >= 3))
                {
                    isAllBombsFilled = true;
                }
            }

            if (isAllBombsFilled)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            Console.WriteLine(bombEffectsQueue.Any() ? string.Join(", ", bombEffectsQueue) : "empty");
            Console.WriteLine(bombCastingStack.Any() ? string.Join(", ", bombEffectsQueue) : "empty");

            foreach (var bomb in bombsList.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{bomb.Name}: {bomb.Count}");
            }
        }
    }
}
