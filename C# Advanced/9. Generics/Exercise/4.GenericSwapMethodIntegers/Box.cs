using System;
using System.Collections.Generic;
using System.Text;

namespace _4.GenericSwapMethodIntegers
{
    public class Box<T>
    {
        private List<T> list;

        public Box()
        {
            this.list = new List<T>();
        }

        public void Add(T element)
        {
            this.list.Add(element);
        }

        public void SwapElements(int firstIndex, int secondIndex)
        {
            var firstElement = this.list[firstIndex];

            this.list[firstIndex] = this.list[secondIndex];
            this.list[secondIndex] = firstElement;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.list
                .ForEach(i => sb.AppendLine($"{i.GetType().FullName}: {i}"));

            return sb.ToString();
        }
    }
}
