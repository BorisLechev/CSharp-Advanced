using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Car
{
    public class Car
    {
        private string make;

        private string model;

        private int year;

        public string Make
        {
            get
            {
                return make;
            }

            set
            {
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                this.model = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }

            set
            {
                this.year = value;
            }
        }
    }
}
