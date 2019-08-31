using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char FOOD_SYMBOL = '*';

        private const int POINTS = 1;

        public FoodAsterisk(Wall wall) 
            : base(wall, FOOD_SYMBOL, POINTS)
        {
        }
    }
}
