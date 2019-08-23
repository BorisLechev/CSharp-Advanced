using _9.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _9.CollectionHierarchy.Collections
{
    public abstract class BaseCollection : IAddable
    {
        protected List<string> Collection { get; private set; } = new List<string>();

        public virtual int Add(string element)
        {
            this.Collection.Insert(0, element);

            return 0;
        }
    }
}
