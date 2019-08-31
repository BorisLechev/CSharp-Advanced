using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char FOOD_SYMBOL = '#';

        private const int POINTS = 3;

        public FoodHash(Wall wall)
            : base(wall, FOOD_SYMBOL, POINTS)
        {
        }
    }
}
