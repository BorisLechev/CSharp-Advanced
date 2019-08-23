using _9.CollectionHierarchy.Collections;
using _9.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _9.CollectionHierarchy
{
    public abstract class BaseCollectionAddAndRemove : BaseCollection, IAddableAndRemovable
    {
        public abstract string Remove();
    }
}
