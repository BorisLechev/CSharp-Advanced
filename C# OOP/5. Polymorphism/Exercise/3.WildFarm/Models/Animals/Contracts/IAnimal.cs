using _3.WildFarm.Models.Foods.Contracts;

namespace _3.WildFarm.Models.Animals.Contracts
{
    public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string AskForFood();

        void Feed(IFood food);
    }
}
