public class Rectangle
{
    public string Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.X = x;
        this.Y = y;
    }

    public bool IsIntersect(Rectangle otherRectangle)
    {
        return otherRectangle.X >= this.X - otherRectangle.Width && otherRectangle.X <= this.X + this.Width &&
               otherRectangle.Y >= this.Y - otherRectangle.Height && otherRectangle.Y <= this.Y + this.Height;
    }
}