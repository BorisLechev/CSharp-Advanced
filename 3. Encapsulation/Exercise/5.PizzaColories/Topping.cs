using System;

public class Topping
{
    private string toppingType;

    private double toppingWeight;

    public string ToppingType
    {
        get { return this.toppingType; }
        private set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese"
                && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.toppingType = value;
        }
    }

    public double ToppingWeight
    {
        get { return this.toppingWeight; }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
            }

            this.toppingWeight = value;
        }
    }

    public Topping(string toppingType, double toppingWeight)
    {
        this.ToppingType = toppingType;
        this.ToppingWeight = toppingWeight;
    }

    public double CalculateToppingCalories()
    {
        double modifier = 0;

        switch (this.ToppingType.ToLower())
        {
            case "meat":
                modifier = 1.2;
                break;
            case "veggies":
                modifier = 0.8;
                break;
            case "cheese":
                modifier = 1.1;
                break;
            case "sauce":
                modifier = 0.9;
                break;
        }

        return (2 * this.ToppingWeight) * modifier;
    }
}