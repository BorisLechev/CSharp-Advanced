using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private Wall wall;

        private char foodSymbol;

        private Random random;

        public Food(Wall wall, char foodSymbol, int points) 
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.FoodPoints = points;
            this.foodSymbol = foodSymbol;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeParts)
        {
            // 2, защото на позиция 0 е стената, а на позиция 1 ще е почти невъзможно да се вземе
            this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
            this.TopY = this.random.Next(2, this.wall.TopY - 2);

            bool isPointOfSnake = snakeParts
                .Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);

                isPointOfSnake = snakeParts
                    .Any(p => p.LeftX == this.LeftX && p.TopY == this.TopY);
            }

            Console.BackgroundColor = ConsoleColor.Red;
            this.Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White; // за да няма trail
        }

        public bool IsFoodPoint(Point snake)
        {
            return snake.LeftX == this.LeftX 
                && snake.TopY == this.TopY;
        }
    }
}
