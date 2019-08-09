using System;
using System.Collections.Generic;
using System.Text;

namespace _7.Tuple
{
    public class Tuple<T, V>
    {
        private readonly T firstItem;

        private readonly V secondItem;

        public Tuple (T firstItem, V secondItem)
        {
            this.firstItem = firstItem;
            this.secondItem = secondItem;
        }

        public string GetInfo()
        {
            return $"{this.firstItem} -> {this.secondItem}";
        }
    }
}
