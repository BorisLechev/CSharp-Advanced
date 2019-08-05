using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;

        private Engine engine;

        private string weight;

        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = "n/a";
            this.Color = "n/a";
        }

        public Car(string model, Engine engine, string weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public Engine Engine
        {
            get => this.engine;
            set => this.engine = value;
        }

        public string Weight
        {
            get => this.weight;
            set => this.weight = value;
        }

        public string Color
        {
            get => this.color;
            set => this.color = value;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder()
                .AppendLine($"{this.Model}:")
                .AppendLine($"  {this.Engine.Model}:")
                .AppendLine($"    Power: {this.Engine.Power}")
                .AppendLine($"    Displacement: {this.Engine.Displacement}")
                .AppendLine($"    Efficiency: {this.Engine.Efficiency}")
                .AppendLine($"  Weight: {this.Weight}")
                .AppendLine($"  Color: {this.Color}");

            return builder.ToString();
        }
    }
}
