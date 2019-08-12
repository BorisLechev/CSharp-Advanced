using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stack;

        private int count;

        public Stack(params T[] stack)
        {
            this.stack = new List<T>(stack);
            this.count = this.stack.Count;
        }

        public int Count => this.stack.Count;

        public void Push(List<T> elements)
        {
            foreach (T element in elements)
            {
                this.stack.Add(element);
                this.count++;
            }
        }

        public void Pop()
        {
            this.stack.RemoveAt(this.stack.Count - 1);
            this.count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                sb.AppendLine(this.stack[i].ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
