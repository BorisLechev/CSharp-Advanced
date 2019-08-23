using _9.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _9.CollectionHierarchy.Collections
{
    public class AddCollection : BaseCollection
    {
        public override int Add(string element)
        {
            this.Collection.Add(element);

            return this.Collection.Count - 1;
        }
    }
}
