using _5.BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5.BorderControl
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
