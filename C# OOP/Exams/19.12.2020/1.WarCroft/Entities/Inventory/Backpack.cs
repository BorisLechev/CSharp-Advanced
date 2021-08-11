namespace WarCroft.Entities.Inventory
{
    public class Backpack : Bag
    {
        private const int CAPACITY = 100;

        public Backpack() 
            : base(CAPACITY)
        {
        }
    }
}
