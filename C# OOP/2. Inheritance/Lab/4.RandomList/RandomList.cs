using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList<T> : List<T>
    {
        private Random rnd;

        public RandomList()
        {
            this.rnd = new Random();
        }

        public T RemoveRandomElement()
        {
            int index = this.rnd.Next(0, this.Count);
            T element = this[index];
            this.RemoveAt(index);

            return element;
        }
    }
}
