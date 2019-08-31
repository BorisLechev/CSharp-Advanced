using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char WALL_SYMBOL = '\u25A0';

        public Wall(int leftX, int topY) 
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < this.LeftX; leftX++)
            {
                this.Draw(leftX, topY, WALL_SYMBOL);
            }
        }

        private void SetVerticaleLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                this.Draw(leftX, topY, WALL_SYMBOL);
            }
        }

        private void InitializeWallBorders()
        {
            this.SetHorizontalLine(0);
            this.SetHorizontalLine(this.TopY);

            this.SetVerticaleLine(0);
            this.SetVerticaleLine(this.LeftX - 1);
        }

        public bool IsPointOfWall(Point snake)
        {
            return snake.LeftX == 0 
                || snake.LeftX == this.LeftX - 1 
                || snake.TopY == 0 
                || snake.TopY == this.TopY - 1;
        }
    }
}
