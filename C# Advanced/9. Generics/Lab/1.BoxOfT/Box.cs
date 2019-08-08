using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> boxItems;

        public Box()
        {
            this.boxItems = new List<T>();
        }

        public int Count
        {
            get => this.boxItems.Count;
        }

        public void Add(T element)
        {
            this.boxItems.Add(element);
        }

        public T Remove()
        {
            T lastElement = this.boxItems.Last();

            this.boxItems.RemoveAt(this.boxItems.LastIndexOf(lastElement));

            return lastElement;
        }
    }
}
