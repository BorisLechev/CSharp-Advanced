using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable // могат да бъдат сравнявани
    {
        private T left;

        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            return this.left.CompareTo(this.right) == 0;
        }

        public void WhichIsHeavier()
        {
            int result = this.left.CompareTo(this.right);

            if (result == 0)
            {
                Console.WriteLine("Right and Left are equal");
            }

            else if (result > 0)
            {
                Console.WriteLine("Left is heavier");
            }

            else
            {
                Console.WriteLine("Right is heavier");
            }
        }
    }
}
