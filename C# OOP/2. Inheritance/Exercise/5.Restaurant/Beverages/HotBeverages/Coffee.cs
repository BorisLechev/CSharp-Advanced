namespace Restaurant.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;

        private const decimal COFFEE_PRICE = 3.5M;

        public Coffee(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {
        }

        public double Caffeine { get; set; }
    }
}
