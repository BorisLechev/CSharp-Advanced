using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(Stack<string> range)
        {
            foreach (string str in range)
            {
                this.Push(str);
            }
        }
    }
}
