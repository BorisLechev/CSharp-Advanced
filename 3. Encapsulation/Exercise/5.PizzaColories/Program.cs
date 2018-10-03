using System;

public class Program
{
    public static void Main()
    {
        try
        {
            string pizzaName = Console.ReadLine().Split()[1];
            Pizza pizza = new Pizza(pizzaName);

            var doughInfo = Console.ReadLine().Split(" ");
            Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));

            pizza.AddDough(dough);

            string toppingInput = string.Empty;

            while ((toppingInput= Console.ReadLine()) != "END")
            {
                var toppingInfo = toppingInput.Split(" ");
                Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
    }
}