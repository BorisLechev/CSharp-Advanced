using _4.PizzaCalories.PizzaIngredients;
using System;

namespace _4.PizzaCalories
{
    public class StartUp
    {
        public static void Main()
        {
            try
            {
                //Dough dough = new Dough();
                //Pizza pizza = new Pizza(dough)
                //string input = String.Empty;

                //while ((input = Console.ReadLine()) != "END")
                //{
                //    string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //    if (tokens[0].ToLower() == "dough")
                //    {
                //        string flourType = tokens[1];
                //        string bakingTechnique = tokens[2];
                //        double weightInGrams = double.Parse(tokens[3]);

                //        dough = new Dough(flourType, bakingTechnique, weightInGrams);

                //        Console.WriteLine($"{dough.Calories:f2}");
                //    }

                //    else if (tokens[0].ToLower() == "topping")
                //    {
                //        string toppingName = tokens[1];
                //        double weightInGrams = double.Parse(tokens[2]);

                //        Topping topping = new Topping(toppingName, weightInGrams);

                //        Console.WriteLine($"{topping.Calories:f2}");
                //    }
                //}

                string[] pizzaInput = Console.ReadLine().Split();
                string pizzaName = pizzaInput[1];


                string[] doughData = Console.ReadLine().Split();
                string flourType = doughData[1];
                string bakingType = doughData[2];
                double weight = double.Parse(doughData[3]);
                Dough dough = new Dough(flourType, bakingType, weight);
                Pizza pizza = new Pizza(pizzaName, dough);

                string input = String.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingInput = input.Split();

                    string type = toppingInput[1];
                    double toppingWeight = double.Parse(toppingInput[2]);
                    Topping topping = new Topping(type, toppingWeight);

                    pizza.AddTopping(topping);
                }

                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
