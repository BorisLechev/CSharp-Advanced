using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;

        private double width;

        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                Validator.ValidateBoxSide(value, "Length");
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                Validator.ValidateBoxSide(value, "Width");
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                Validator.ValidateBoxSide(value, "Height");
                this.height = value;
            }
        }

        public void SurfaceOfTheBox(double length, double width, double height)
        {
            Console.WriteLine($"Surface Area - {2 * length * width + 2 * length * height + 2 * width * height:f2}");
        }

        public void LateralSurfaceOfTheBox(double length, double width, double height)
        {
            Console.WriteLine($"Lateral Surface Area - {2 * length * height + 2 * width * height:f2}");
        }

        public void VolumeOfTheBox(double length, double width, double height)
        {
            Console.WriteLine($"Volume - {length * width * height:f2}");
        }
    }
}
