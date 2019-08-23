using System;
using System.Collections.Generic;
using System.Text;

namespace _7.FoodShortage.Interfaces
{
    public interface IBuyer
    {
        int Food { get; }

        void BuyFood();
    }
}
