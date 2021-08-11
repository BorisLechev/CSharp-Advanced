using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    //This is a base class for any bags and it should not be able to be instantiated.
    public abstract class Bag : IBag
    {
        private readonly List<Item> items;

        private Bag()
        {
            this.items = new List<Item>();
        }

        public Bag(int capacity)
            : this()
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; set; } = 100;

        public int Load => this.items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity) 
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Any() == false)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            Item item = this.items.SingleOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                var message = string.Format(ExceptionMessages.ItemNotFoundInBag, name);

                throw new ArgumentException(message);
            }

            this.items.Remove(item);

            return item;
        }
    }
}
