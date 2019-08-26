using P02.DrawingShape_After;
using System.Collections.Generic;
using System.Linq;

namespace P02._DrawingShape_Before.Contracts
{
    public interface IDrawingManager
    {
        public void Draw(IShape shape)
        {
            List<IDrawingManager> drewers = new List<IDrawingManager>();
            {
                new DrawingCircle(),
                new RectangleDrawer()
            };

            drawers.First(x => x.IsMatch(shape)).Draw(shape);
        }
    }
}
