namespace P02._DrawingShape_Before
{
    using Contracts;
    using P02.DrawingShape_After;

    class DrawingManager : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            IDrawingManager drawer = null;

            if (shape is Circle)
            {
                drawer = new DrawingCircle();
            }
            else if (shape is Rectangle)
            {
                drawer = new RectangleDrawer();
            }

            drawer.Draw(shape);
        }
    }
}
