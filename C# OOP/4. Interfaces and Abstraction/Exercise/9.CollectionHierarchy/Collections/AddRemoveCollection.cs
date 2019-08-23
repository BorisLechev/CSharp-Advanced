using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _9.CollectionHierarchy.Collections
{
    public class AddRemoveCollection : BaseCollectionAddAndRemove
    {
        public override string Remove()
        {
            if (this.Collection.Any())
            {
                string lastElement = this.Collection.LastOrDefault();
                this.Collection.RemoveAt(this.Collection.Count - 1);

                return lastElement;
            }

            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
