using System;
using System.Collections.Generic;
using System.Text;

public class Box
{
    private double length;

    private double width;

    private double height;

    public double Length
    {
        get { return this.length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }

            this.length = value;
        }
    }

    public double Width
    {
        get { return this.width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }

            this.width = value;
        }
    }

    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }

            this.height = value;
        }
    }

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