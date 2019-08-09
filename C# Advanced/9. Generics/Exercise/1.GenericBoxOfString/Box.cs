using System;
using System.Collections.Generic;
using System.Text;

namespace _1.GenericBoxOfString
{
    public class Box<T>
    {
        private List<T> boxCollection;

        public Box()
        {
            this.boxCollection = new List<T>();
        }

        // за енкапсулация
        public void Add(T item)
        {
            this.boxCollection.Add(item);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var text in this.boxCollection)
            {
                sb.AppendLine($"{text.GetType().FullName}: {text.ToString()}");
            }

            return sb.ToString();
        }
    }
}
