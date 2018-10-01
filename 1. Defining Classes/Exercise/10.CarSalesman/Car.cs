using System.Text;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public double? Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine, double weight = 0.0, string color = "n/a")
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public override string ToString()
    {
        string weight = this.Weight == 0.0 ? "n/a" : this.Weight.ToString();
        string color = this.Color == null ? "n/a" : this.Color.ToString();

        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"{this.Model}:");
        builder.AppendLine($"  {this.Engine.Model}:");
        builder.AppendLine($"    Power: {this.Engine.Power}");
        builder.AppendLine($"    Displacement: {this.Engine.Displacement}");
        builder.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
        builder.AppendLine($"  Weight: {weight}");
        builder.Append($"  Color: {color}");

        return builder.ToString();
    }
}