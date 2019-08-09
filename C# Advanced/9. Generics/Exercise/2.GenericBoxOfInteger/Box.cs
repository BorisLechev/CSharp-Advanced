using System;
using System.Collections.Generic;
using System.Text;

namespace _2.GenericBoxOfInteger
{
    public class Box<T>
    {
        private List<T> list;

        public Box()
        {
            this.list = new List<T>();
        }

        public void Add(T number)
        {
            this.list.Add(number);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.list
                .ForEach(l => sb.AppendLine($"{l.GetType().FullName}: {l}"));

            return sb.ToString();
        }
    }
}
