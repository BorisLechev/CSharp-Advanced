using _3.WildFarm.Models.Animals.Contracts;
using _3.WildFarm.Models.Animals.Entities;
using _3.WildFarm.Models.Foods.Contracts;
using _3.WildFarm.Models.Foods.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.WildFarm.Core
{
    public class Engine
    {
        private List<Animal> animals;
        private FoodFactory foodFactory;

        public Engine()
        {
            animals = new List<Animal>();
            foodFactory = new FoodFactory();
        }

        public void Run()
        {
            string command = String.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string foodInput = Console.ReadLine();

                IAnimal animal = GetAnimal(command);
                IFood food = GetFood(foodInput);

                Console.WriteLine(animal.AskForFood());

                try
                {
                    animal.Feed(food);
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                }
            }

            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (Animal animal in this.animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        private IFood GetFood(string foodInput)
        {
            string[] foodTokens =
                foodInput
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string foodType = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            IFood food = this.foodFactory.ProduceFood(foodType, quantity);

            return food;
        }

        private Animal GetAnimal(string command)
        {
            string[] tokens = 
                command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string type = tokens[0];
            string name = tokens[1];
            double weight = double.Parse(tokens[2]);

            Animal animal;

            if (type == "Owl")
            {
                double wingSize = double.Parse(tokens[3]);

                animal = new Owl(name, weight, wingSize);
            }

            else if (type == "Hen")
            {
                double wingSize = double.Parse(tokens[3]);

                animal = new Hen(name, weight, wingSize);
            }

            else
            {
                string livingRegion = tokens[3];

                if (type == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }

                else if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, livingRegion);
                }

                else
                {
                    string breed = tokens[4];

                    if (type == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }

                    else if (type == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }

                    else
                    {
                        throw new InvalidOperationException("Invalid animal type!");
                    }
                }
            }

            this.animals.Add(animal);

            return animal;
        }
    }
}
