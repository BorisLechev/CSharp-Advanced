﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char FOOD_SYMBOL = '$';

        private const int POINTS = 2;

        public FoodDollar(Wall wall)
            : base(wall, FOOD_SYMBOL, POINTS)
        {
        }
    }
}
