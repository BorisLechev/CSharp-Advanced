using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;

    private Dough Dough { get; set; }

    private List<Topping> toppings;

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (value.Length < 1 || value.Length > 15 || value == string.Empty)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public List<Topping> Toppings
    {
        get { return this.toppings; }
        private set
        {
            if (value.Count < 0 || value.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings = value;
        }
    }

    public Pizza(string name)
    {
        this.Name = name;
        this.Toppings = new List<Topping>();
    }

    public Pizza(Dough dough, string name, List<Topping> toppings)
    {
        this.Dough = dough;
        this.Name = name;
        this.Toppings = toppings;
    }

    public void AddDough(Dough dough)
    {
        this.Dough = dough;
    }

    public void AddTopping(Topping topping)
    {
        if (this.Toppings.Count > 10)
        {
            throw new ArgumentException($"Number of toppings should be in range [0..10].");
        }
        this.Toppings.Add(topping);
    }

    public double TotalCalories()
    {
        return this.Dough.CalculateDoughCalories() + this.Toppings.Sum(x => x.CalculateToppingCalories());
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.TotalCalories():f2} Calories.";
    }
}