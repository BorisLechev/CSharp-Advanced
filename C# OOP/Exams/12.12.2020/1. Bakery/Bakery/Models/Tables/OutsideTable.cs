namespace Bakery.Models.Tables
{
    public class OutsideTable : Table
    {
        private const decimal INITIAL_PRICE_PER_PERSON = 3.50M;

        public OutsideTable(int tableNumber, int capacity) 
            : base(tableNumber, capacity, INITIAL_PRICE_PER_PERSON)
        {
        }
    }
}
