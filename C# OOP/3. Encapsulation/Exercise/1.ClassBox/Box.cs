using System;

public class Box
{
    public double Length { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public void SurfaceOfTheBox(double length, double width, double height)
    {
        Console.WriteLine($"Surface Area – {2 * length * width + 2 * length * height + 2 * width * height:f2}");
    }

    public void LateralSurfaceOfTheBox(double length, double width, double height)
    {
        Console.WriteLine($"Lateral Surface Area – {2 * length * height + 2 * width * height:f2}");
    }

    public void VolumeOfTheBox(double length, double width, double height)
    {
        Console.WriteLine($"Volume – {length * width * height:f2}");
    }
}