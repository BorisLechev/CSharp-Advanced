using _9.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9.CollectionHierarchy.Collections
{
    public class MyList : BaseCollectionAddAndRemove, IUsable
    {
        public int Used => this.Collection.Count;

        public override string Remove()
        {
            if (this.Collection.Any())
            {
                string element = this.Collection.First();
                this.Collection.RemoveAt(0);
                return element;
            }

            throw new InvalidOperationException();
        }
    }
}
