using System;
using System.Collections.Generic;
using System.Text;

namespace _8.Threeuple
{
    public class Threeuple<T, V, W>
    {
        private readonly T firstElement;

        private readonly V secondElement;

        private readonly W thirdElement;

        public Threeuple(T firstElement, V secondElement, W thirdElement)
        {
            this.firstElement = firstElement;
            this.secondElement = secondElement;
            this.thirdElement = thirdElement;
        }

        public string GetInfo()
        {
            return $"{this.firstElement} -> {this.secondElement} -> {this.thirdElement}";
        }
    }
}
