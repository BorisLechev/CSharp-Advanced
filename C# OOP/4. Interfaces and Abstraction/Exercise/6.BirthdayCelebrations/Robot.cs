using _6.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _6.BirthdayCelebrations
{
    public class Robot : IIdentifiable
    {
        private string model;

        public Robot(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}
