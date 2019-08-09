using System;
using System.Collections.Generic;
using System.Text;

namespace _6.GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> list;

        public Box()
        {
            this.list = new List<T>();
        }

        public int Counter { get; private set; }

        public void Add(T element)
        {
            this.list.Add(element);
        }

        public void CountOfElementsGreaterThan(T element)
        {
            foreach (var item in this.list)
            {
                if (item.CompareTo(element) > 0)
                {
                    this.Counter++;
                }
            }
        }
    }
}
