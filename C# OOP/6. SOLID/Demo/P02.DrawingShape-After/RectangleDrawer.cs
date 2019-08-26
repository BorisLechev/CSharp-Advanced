using P02._DrawingShape_Before;
using P02._DrawingShape_Before.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.DrawingShape_After
{
    public class RectangleDrawer : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            var rectangle = shape as Rectangle;

            Console.WriteLine("Rec drawed.");
        }

        public bool IsMatch(IShape shape)
        {
            if (shape is Rectangle)
            {
                return true;
            }

            return false;
        }
    }
}
