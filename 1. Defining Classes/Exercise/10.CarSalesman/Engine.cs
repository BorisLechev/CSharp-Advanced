public class Engine
{
    public string Model { get; set; }
    public double Power { get; set; }
    public double Displacement { get; set; }
    public string Efficiency { get; set; }

    public Engine(string model, double power, double displacement, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }
}